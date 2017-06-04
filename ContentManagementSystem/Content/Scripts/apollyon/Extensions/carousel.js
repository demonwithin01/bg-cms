var apollyon;
(function (apollyon) {
    $.fn.carousel = function (options) {
        function Carousel(element) {
            var _itemsTotalWidth = 0;
            var _carouselWidth;
            var $inner;
            var $items;
            var $nextButton;
            var $prevButton;
            var that = this;
            this.methods = {
                refresh: function () {
                    $items = $inner.children('.carousel-item');
                    $prevButton.off('click', previousClicked);
                    $nextButton.off('click', nextClicked);
                    var left = 0;
                    _itemsTotalWidth = 0;
                    _carouselWidth = parseInt($inner.width());
                    $items.each(function () {
                        _itemsTotalWidth += $(this).width();
                    });
                    if (_itemsTotalWidth < _carouselWidth) {
                        left = (_carouselWidth - _itemsTotalWidth) / 2;
                        $prevButton.hide();
                        $nextButton.hide();
                    }
                    else {
                        $prevButton.on('click', previousClicked).addClass('hidden');
                        $nextButton.on('click', nextClicked).removeClass('hidden');
                    }
                    $items.each(function (index, element) {
                        var $element = $(element);
                        $element.css('left', left);
                        left += $element.width();
                    }).removeClass('pole-position').first().addClass('pole-position');
                    $inner.css('left', 0);
                }
            };
            function nextClicked() {
                var $pole = $items.filter('.pole-position');
                var $next = $pole.next();
                if ($next.length == 0) {
                    return;
                }
                if ($next.index() > 0) {
                    $prevButton.removeClass('hidden');
                }
                var position = 0;
                $next.prevAll().each(function () {
                    position += $(this).width();
                });
                if ($next.index() == $items.length - 2) {
                    position = _itemsTotalWidth - _carouselWidth;
                    $nextButton.addClass('hidden');
                }
                $pole.removeClass('pole-position');
                $next.addClass('pole-position');
                $inner.css('left', -position);
            }
            function previousClicked() {
                var $pole = $items.filter('.pole-position');
                var $prev = $pole.prev();
                if ($pole.index() < $inner.children().length) {
                    $nextButton.removeClass('hidden');
                }
                if ($prev.length == 0) {
                    return;
                }
                var position = 0;
                $prev.prevAll().each(function () {
                    position += $(this).width();
                });
                if ($prev.index() == 0) {
                    position = 0;
                    $prevButton.addClass('hidden');
                }
                $pole.removeClass('pole-position');
                $prev.addClass('pole-position');
                $inner.css('left', -position);
            }
            function handleResize() {
                that.methods.refresh();
            }
            $inner = element.find('.carousel-inner');
            $nextButton = element.find('.carousel-next');
            $prevButton = element.find('.carousel-previous');
            $(window).on('resize', handleResize);
            this.methods.refresh();
        }
        if (typeof (options) === 'string') {
            var carousel = this.data('bg-carousel');
            if (!carousel) {
                return;
            }
            if (typeof (carousel.methods[options]) === 'function') {
                carousel.methods[options].call(this);
            }
        }
        else {
            this.data('bg-carousel', new Carousel(this));
        }
        return this;
    };
})(apollyon || (apollyon = {}));
