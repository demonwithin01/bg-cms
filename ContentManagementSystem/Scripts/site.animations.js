function Animations()
{
    var that = this;

    this.addClass = function($el, value, callback)
    {
        function transitionEnd()
        {
            $el.off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
            if (typeof (callback) == 'function')
            {
                callback($el);
            }
        }

        $el.on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
        $el.addClass(value);
    }

    this.removeClass = function($el, value, callback)
    {
        function transitionEnd()
        {
            $el.off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
            if (typeof (callback) == 'function')
            {
                callback($el);
            }
        }

        $el.on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
        $el.addClass(value);
    }

    this.height = function (el, height, callback)
    {
        if (height == 'auto')
        {
            animateHeightAuto($(el)[0], callback);
        }
        else
        {
            animateHeightTo($(el)[0], parseInt(height), callback);
        }
    }

    var animateHeightTo = function (element, height, callback)
    {
        function transitionEnd()
        {
            $(element).off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
            if (typeof (callback) == 'function')
            {
                callback($(element));
            }
        }

        var prevHeight = getComputedStyle(element).height;
        element.style.height = prevHeight;
        element.offsetHeight;
        $(element).on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
        element.style.height = height;
    }

    var animateHeightAuto = function (element, callback)
    {
        function transitionEnd()
        {
            element.style.height = 'auto';
            $(element).off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
            if (typeof (callback) == 'function')
            {
                callback($(element));
            }
        }

        var prevHeight = element.style.height;
        element.style.height = 'auto';
        var endHeight = getComputedStyle(element).height;
        element.style.height = prevHeight;
        element.offsetHeight;
        $(element).on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', transitionEnd);
        element.style.height = endHeight;
    }
}