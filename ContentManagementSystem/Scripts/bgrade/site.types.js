var bgrade;
(function (bgrade) {
    (function (notificationType) {
        notificationType[notificationType["success"] = 1] = "success";
        notificationType[notificationType["warning"] = 2] = "warning";
        notificationType[notificationType["error"] = 3] = "error";
    })(bgrade.notificationType || (bgrade.notificationType = {}));
    var notificationType = bgrade.notificationType;
})(bgrade || (bgrade = {}));
//# sourceMappingURL=site.types.js.map