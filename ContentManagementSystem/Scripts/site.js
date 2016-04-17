function Site()
{
    var that = this;

    this.contactForm = new Contact();
    this.notification = new Notification();
    this.animate = new Animations();

    function init()
    {
        $( '#social' ).jsSocials( {
            shares: ['facebook', 'twitter', 'googleplus', 'linkedin', 'pinterest', 'stumbleupon', 'whatsapp']
        } );

        attachEventHandlers();

        $( window ).resize();

        setTimeout(function ()
        {
            $( '#body' ).addClass( 'on' );
        }, 600 )
    }

    function attachEventHandlers()
    {
        $( window ).on( 'resize', handleResize );
        $( '.menu-link' ).on( 'click', handleMenuLinkClick );
        $( 'header + .page-content' ).on( 'scroll', handleScroll );
    }

    function handleResize()
    {
        if ( window.innerWidth < 960 )
        {
            $( 'header' ).removeClass( 'always-open' );
        }
        else
        {
            $( 'header' ).addClass( 'always-open' ).removeClass( 'open' ).removeClass( 'changing' );
        }

        $( '#body' ).css( {
            'padding-bottom': $( 'footer' ).outerHeight(),
            'padding-top': $( '.page-header' ).outerHeight(),
        } );
    }

    function handleMenuLinkClick()
    {
        var $parent = $( this ).parent();
        $parent.toggleClass( 'open' );

        if ( $parent.hasClass( 'open' ) == false )
        {
            $parent.addClass( 'changing' );

            setTimeout( function ()
            {
                $parent.addClass( 'changing' );
            }, 300 );
        }
    }

    function handleScroll(e)
    {
        console.log( e );
        $( '#social' ).css( 'top', e.target.offsetTop + 'px' );
    }

    init();
}