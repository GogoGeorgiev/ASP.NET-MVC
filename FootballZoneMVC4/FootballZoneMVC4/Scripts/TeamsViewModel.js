/// <reference path="_references.js" />

(function (window, undefined) {
    // Define the "MyApp" namespace
    var MyApp = window.MyApp = window.MyApp || {};

    // Team class
    var entityType = "Team:#FootballZoneMVC4.DAL";
    MyApp.Team = function (data) {
        var self = this;

        // Underlying data
        self.TeamID = ko.observable(data.TeamID);
        self.Name = ko.observable(data.Name);
        self.Biography = ko.observable(data.Biography);
        self.CountryID = ko.observable(data.CountryID);
        self.Country = ko.observable(upshot.map(data.Country, "Country:#FootballZoneMVC4.DAL"));
        upshot.addEntityProperties(self, entityType);
    }

    // TeamsViewModel class
    MyApp.TeamsViewModel = function (options) {
        var self = this;

        // Private properties
        var dataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetTeams" },
            entityType: entityType,
            bufferChanges: true,
            mapping: MyApp.Team
        };
        var gridDataSource = new upshot.RemoteDataSource(dataSourceOptions);
        var editorDataSource = new upshot.RemoteDataSource(dataSourceOptions);
        var parentEntitiesOperationParameters = {};
        var countriesDataSource = new upshot.RemoteDataSource({
            providerParameters: { url: options.serviceUrl, operationName: "GetCountryOptionsForTeam", operationParameters: parentEntitiesOperationParameters },
            entityType: "Country:#FootballZoneMVC4.DAL",
            dataContext: editorDataSource.getDataContext()
        });

        // Data
        self.teams = gridDataSource.getEntities();
        self.countries = countriesDataSource.getEntitiesWithStatus({ capacity: 100 });
        self.editingTeam = editorDataSource.getFirstEntity();
        self.successMessage = ko.observable().extend({ notify: "always" });
        self.errorMessage = ko.observable().extend({ notify: "always" });
        self.paging = new upshot.PagingModel(gridDataSource, {
            onPageChange: function (pageIndex, pageSize) {
                self.nav.navigate({ page: pageIndex, pageSize: pageSize });
            }
        });
        self.validationConfig = $.extend({
            resetFormOnChange: self.editingTeam,
            submitHandler: function () { self.saveEdit() }
        }, editorDataSource.getEntityValidationRules());

        // Client-side navigation
        self.nav = new NavHistory({
            params: { edit: null, page: 1, pageSize: 10 },
            onNavigate: function (navEntry, navInfo) {
                self.paging.moveTo(navEntry.params.page, navEntry.params.pageSize);

                // Wipe out any old data so that it is not displayed in the UI while new data is being loaded 
                editorDataSource.revertChanges();
                editorDataSource.reset();
                countriesDataSource.reset();

                if (navEntry.params.edit) {
                    parentEntitiesOperationParameters.TeamID = Number(navEntry.params.edit) || null;
                    
                    // Load the list of countries allowed for this particular team
                    countriesDataSource.refresh();

                    if (navEntry.params.edit == "new") {
                        // Create and begin editing a new team instance
                        editorDataSource.getEntities().push(new MyApp.Team({}));
                    } else {
                        // Load and begin editing an existing team instance
                        editorDataSource.setFilter({ property: "TeamID", value: Number(navEntry.params.edit) }).refresh();
                    }
                } else {
                    // Not editing, so load the requested page of data to display in the grid
                    gridDataSource.refresh();
                }
            }
        }).initialize({ linkToUrl: true });

        // Public operations
        self.saveEdit = function () {
            editorDataSource.commitChanges(function () {
                self.successMessage("Saved Team").errorMessage("");
                self.showGrid();
            });
        }
        self.revertEdit = function () { editorDataSource.revertChanges() }
        self.editTeam = function (team) { self.nav.navigate({ edit: team.TeamID() }) }
        self.showGrid = function () { self.nav.navigate({ edit: null }) }
        self.createTeam = function () { self.nav.navigate({ edit: "new" }) }
        self.deleteTeam = function (team) {
            editorDataSource.deleteEntity(team);
            editorDataSource.commitChanges(function () {
                self.successMessage("Deleted Team").errorMessage("");
                self.showGrid();
            });
        };

        // Error handling
        var handleServerError = function (httpStatus, message) {
            if (httpStatus === 200) {
                // Application domain error (e.g., validation error)
                self.errorMessage(message).successMessage("");
            } else {
                // System error (e.g., unhandled exception)
                self.errorMessage("Server error: HTTP status code: " + httpStatus + ", message: " + message).successMessage("");
            }
        }
        
        gridDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
        editorDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
    }
})(window);

