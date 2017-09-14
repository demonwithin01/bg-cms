var apollyon;
(function (apollyon) {
    var BannerItem = (function () {
        function BannerItem() {
        }
        return BannerItem;
    }());
    var BannerAdmin = (function () {
        function BannerAdmin(initialItems) {
            var that = this;
            this._bannerItems = [];
            this._currentSlide = null;
            $("#ContentModel_urlSectorField").on("change", function () {
                if (that._currentSlide == null) {
                    return;
                }
                that._bannerItems[that._currentSlide.index()].pageId = $(this).val();
            });
            for (var i = 0; i < initialItems.length; i++) {
                var newBannerItem = new BannerItem();
                newBannerItem.uploadId = initialItems[i].uploadId;
                newBannerItem.imgUrl = initialItems[i].imgUrl;
                newBannerItem.pageId = initialItems[i].pageId;
                this._bannerItems.push(newBannerItem);
                var slide = $("<div class=\"carousel-item\" style=\"display: none;\"></div>");
                slide.append("<img src=\"" + newBannerItem.imgUrl + "\" />");
                var thumbnail = $("<li></li>");
                thumbnail.append("<img src= \"" + newBannerItem.imgUrl + "\">");
                $(".admin-carousel-tray > ul").append(thumbnail);
                $(".admin-carousel .carousel-inner").append(slide);
                if (i == 0) {
                    this._currentSlide = slide;
                    $("#ContentModel_urlSectorField").val(newBannerItem.pageId);
                    this._currentSlide.show();
                }
            }
            this._uploadSelector = new apollyon.UploadSelector({
                uploadSelected: $.proxy(this.uploadSelected, this)
            });
            $("#selectPicture").on("click", function () {
                if (that._currentSlide == null) {
                    return;
                }
                that._uploadSelector.open();
            });
            $("#acceptBannerEditor").on("click", function () {
                that.apply();
            });
            $("#removeSlide").on("click", function () {
                that.removeSlide();
            });
            $(".admin-carousel-add.add-left").on("click", function () {
                that.addSlide(true);
            });
            $(".admin-carousel-add.add-right").on("click", function () {
                that.addSlide(false);
            });
            $(".admin-carousel-tray ul").on("click", "li", function () {
                that.selectSlide($(".admin-carousel .carousel-item").eq($(this).index()));
            });
        }
        /**
         * Applies the selected carousel items to the page.
         */
        BannerAdmin.prototype.apply = function () {
            var currentGridItem = window.getCurrentGridItem();
            currentGridItem.siblings(".content-json").val(JSON.stringify({
                slides: this._bannerItems,
                bannerType: $("#ContentModel_BannerType").val(),
                width: $("#ContentModel_Width").val(),
                height: $("#ContentModel_Height").val()
            }));
            $(".admin-carousel").closest(".modal-content").parent().bgmodal("close");
        };
        /**
         * Removes the current slide from the page.
         */
        BannerAdmin.prototype.removeSlide = function () {
            if (this._currentSlide == null) {
                return;
            }
            var slide = this._currentSlide.prev();
            if (slide.length == 0) {
                slide = this._currentSlide.next();
            }
            var index = this._currentSlide.index();
            this._bannerItems = this._bannerItems.splice(index, 1);
            this._currentSlide.remove();
            $(".admin-carousel-tray ul").children().eq(index).remove();
            this._currentSlide = null;
            this.updateTrayWidth();
            if (slide.length > 0) {
                this.selectSlide(slide);
            }
        };
        /**
         * Callback for the selected upload.
         * @param data The selected upload data.
         */
        BannerAdmin.prototype.uploadSelected = function (data) {
            this._currentSlide.children("img").attr("src", data.imgSrc);
            $(".admin-carousel-tray ul li").eq(this._currentSlide.index()).children("img").attr("src", data.imgSrc);
            var bannerItem = this._bannerItems[this._currentSlide.index()];
            bannerItem.uploadId = data.uploadId;
            bannerItem.imgUrl = data.imgSrc;
            this._uploadSelector.close();
        };
        /**
         * Adds a new slide to the banner.
         * @param addToLeft Whether to add the slide to the left.
         */
        BannerAdmin.prototype.addSlide = function (addToLeft) {
            var slide = $("<div class=\"carousel-item\" style=\"display: none;\"></div>");
            slide.append("<img src=\"\" />");
            var thumbnail = $("<li></li>");
            thumbnail.append("<img src= \"\">");
            var newBannerItem = new BannerItem();
            if (this._currentSlide == null) {
                this._bannerItems.push(newBannerItem);
                $(".admin-carousel-tray > ul").append(thumbnail);
                $(".admin-carousel .carousel-inner").append(slide);
            }
            else {
                var currentIndex = this._currentSlide.index();
                if (addToLeft) {
                    this._bannerItems = this._bannerItems.splice(currentIndex, 0, newBannerItem);
                    thumbnail.insertBefore($(".admin-carousel-tray > ul > li").eq(currentIndex));
                    slide.insertBefore(this._currentSlide);
                }
                else {
                    if (currentIndex < this._bannerItems.length) {
                        this._bannerItems.push(newBannerItem);
                    }
                    else {
                        this._bannerItems = this._bannerItems.splice(currentIndex + 1, 0, newBannerItem);
                    }
                    thumbnail.insertAfter($(".admin-carousel-tray > ul > li").eq(currentIndex));
                    slide.insertAfter(this._currentSlide);
                }
            }
            this.updateTrayWidth();
            this.selectSlide(slide);
        };
        /**
         * Updates the tray width to force a scrollbar.
         */
        BannerAdmin.prototype.updateTrayWidth = function () {
            $(".admin-carousel-tray ul").width(164 * $(".admin-carousel-tray ul").children().length - 4);
        };
        /**
         * Selects the provided slide.
         * @param slide The slide to focus on.
         */
        BannerAdmin.prototype.selectSlide = function (slide) {
            if (this._currentSlide) {
                this._currentSlide.hide();
            }
            this._currentSlide = slide;
            this._currentSlide.show();
            $("#ContentModel_urlSectorField").val(this._bannerItems[this._currentSlide.index()].pageId);
        };
        return BannerAdmin;
    }());
    apollyon.BannerAdmin = BannerAdmin;
})(apollyon || (apollyon = {}));
//# sourceMappingURL=Banner.js.map