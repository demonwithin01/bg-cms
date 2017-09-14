var apollyon;
(function (apollyon) {
    var notificationType;
    (function (notificationType) {
        notificationType[notificationType["success"] = 1] = "success";
        notificationType[notificationType["warning"] = 2] = "warning";
        notificationType[notificationType["error"] = 3] = "error";
    })(notificationType = apollyon.notificationType || (apollyon.notificationType = {}));
    var BannerType;
    (function (BannerType) {
        BannerType[BannerType["Carousel"] = 1] = "Carousel";
        BannerType[BannerType["FadeOver"] = 2] = "FadeOver";
    })(BannerType = apollyon.BannerType || (apollyon.BannerType = {}));
})(apollyon || (apollyon = {}));
//# sourceMappingURL=site.types.js.map