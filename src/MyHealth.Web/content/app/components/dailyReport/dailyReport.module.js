var moduleName = 'SmartClinic.dailyReport';

import DailyReportController from './controllers/dailyReportController';

angular.module(moduleName, []).
    controller('dailyReportController', DailyReportController);

export default moduleName;