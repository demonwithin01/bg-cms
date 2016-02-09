function Contact()
{
    var that = this;
    
    this.contactFormSubmitted = function (data)
    {
        console.log(data);
    }

    this.toggleForm = function ()
    {
        var $wrapper = $('#contactFormWrapper');

        if ($wrapper.hasClass('busy')) return;

        $wrapper.addClass('busy');

        if ($wrapper.hasClass('open'))
        {
            _site.animate.height($wrapper, 0, function ()
            {
                $wrapper.removeClass('busy open');
            });
        }
        else
        {
            _site.animate.height($wrapper, 'auto', function ()
            {
                $wrapper.removeClass('busy').addClass('open');
            });
        }
    }

    var showForm = function ()
    {

    }

    var hideForm = function ()
    {

    }
}