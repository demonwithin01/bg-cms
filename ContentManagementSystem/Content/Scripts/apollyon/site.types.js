var apollyon;
(function (apollyon) {
    (function (notificationType) {
        notificationType[notificationType["success"] = 1] = "success";
        notificationType[notificationType["warning"] = 2] = "warning";
        notificationType[notificationType["error"] = 3] = "error";
    })(apollyon.notificationType || (apollyon.notificationType = {}));
    var notificationType = apollyon.notificationType;
    (function (BannerType) {
        BannerType[BannerType["Carousel"] = 1] = "Carousel";
    })(apollyon.BannerType || (apollyon.BannerType = {}));
    var BannerType = apollyon.BannerType;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=site.types.js.map