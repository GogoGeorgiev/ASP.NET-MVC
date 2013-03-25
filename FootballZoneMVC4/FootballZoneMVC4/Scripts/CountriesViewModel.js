/// <reference path="_references.js" />

(function (window, undefined) {
    // Define the "MyApp" namespace
    var MyApp = window.MyApp = window.MyApp || {};

    // Country class
    var entityType = "Country:#FootballZoneMVC4.DAL";
    MyApp.Country = function (data) {
        var self = this;

        // Underlying data
        self.CountryID = ko.observable(data.CountryID);
        self.Name = ko.observable(data.Name);
        upshot.addEntityProperties(self, entityType);
    }

    // CountriesViewModel class
    MyApp.CountriesViewModel = function (options) {
        var self = this;

        // Private properties
        var dataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetCountries" },
            entityType: entityType,
            bufferChanges: true,
            mapping: MyApp.Country
        };
        var gridDataSource = new upshot.RemoteDataSource(dataSourceOptions);
        var editorDataSource = new upshot.RemoteDataSource(dataSourceOptions);

        // Data
        self.countries = gridDataSource.getEntities();
        self.editingCountry = editorDataSource.getFirstEntity();
        self.successMessage = ko.observable().extend({ notify: "always" });
        self.errorMessage = ko.observable().extend({ notify: "always" });
        self.paging = new upshot.PagingModel(gridDataSource, {
            onPageChange: function (pageIndex, pageSize) {
                self.nav.navigate({ page: pageIndex, pageSize: pageSize });
            }
        });
        self.validationConfig = $.extend({
            resetFormOnChange: self.editingCountry,
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

                if (navEntry.params.edit) {
                    
                    if (navEntry.params.edit == "new") {
                        // Create and begin editing a new country instance
                        editorDataSource.getEntities().push(new MyApp.Country({}));
                    } else {
                        // Load and begin editing an existing country instance
                        editorDataSource.setFilter({ property: "CountryID", value: Number(navEntry.params.edit) }).refresh();
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
                self.successMessage("Saved Country").errorMessage("");
                self.showGrid();
            });
        }
        self.revertEdit = function () { editorDataSource.revertChanges() }
        self.editCountry = function (country) { self.nav.navigate({ edit: country.CountryID() }) }
        self.showGrid = function () { self.nav.navigate({ edit: null }) }
        self.createCountry = function () { self.nav.navigate({ edit: "new" }) }
        self.deleteCountry = function (country) {
            editorDataSource.deleteEntity(country);
            editorDataSource.commitChanges(function () {
                self.successMessage("Deleted Country").errorMessage("");
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

