outofmars.navigation = function ( mySite )
{
    var base = site.plugin.call( this );
    var _site = mySite;

    var _windowDimensions;
    var _scrollPos;
    var _direction = 1;
    var _canvas;
    var _context;
    var _end = 0;

    this.initialise = function ()
    {
        return;
        _canvas = $( "<canvas style=\"position: absolute; top: 0; left: -40px\">" );
        $( "header > nav" ).prepend( _canvas );

        _canvas = _canvas.get( 0 );

        _context = _canvas.getContext( "2d" );

        _canvas.width = $( "header > nav" ).width() + 40;
        _canvas.height = $( "header > nav" ).height();

        setInterval( function ()
        {
            var x = -40,
                y = 0,
                w = _canvas.width + 40,
                h = _canvas.height;

            _context.clearRect( x, y, w, h );

            //console.log( "x: " + x + ", y: " + y + ", w: " + w + ", h: " + h );
            //console.log( _end );

            var gradient = _context.createLinearGradient( x, y, w, 0 );

            _end += ( 0.01 * _direction );

            if ( _end <= 0 )
            {
                _end = 0;
                gradient.addColorStop( 0, "rgba(40, 89, 165, 0)" );
                gradient.addColorStop( 1, "rgba(45, 121, 183, 0)" );
            }
            else
            {
                if ( _end >= 1 )
                {
                    _end = 1;
                }

                gradient.addColorStop( 0, "rgb(40, 89, 165)" );
                gradient.addColorStop( _end, "rgb(45, 121, 183)" );
            }

            if( _end >= 1 )
            {
                _end = 1;
            }
            else
            {
                gradient.addColorStop( 1, "rgba(45, 121, 183, 0)" );
            }

            _context.fillStyle = gradient;
            _context.fillRect(x, y, w, h);
        }, 5 );

        //100% { background: linear-gradient(135deg, rgba(40,89,165,1) 0%,rgba(45,121,183,1) 100%); }
    }

    this.onWindowResize = function ( dim )
    {
        _windowDimensions = dim;

        if ( dim.width < 960 )
        {
            $( 'header' ).removeClass( 'always-open' );
        }
        else
        {
            $( 'header' ).addClass( 'always-open' ).removeClass( 'open' ).removeClass( 'changing' );

            if ( _scrollPos.top > 0 )
            {
                $( "header" ).addClass( "scrolled" );
                _direction = 1;
            }
        }
    };

    this.onMainContentScroll = function ( pos )
    {
        _scrollPos = pos;

        if ( _scrollPos.top > 0 && $( "header" ).hasClass( "always-open" ) )
        {
            $( "header" ).addClass( "scrolled" );
            _direction = 1;
        }
        else
        {
            $( "header" ).removeClass( "scrolled" );
            _direction = -1;
        }
    };
};

outofmars.navigation.prototype = Object.create( site.plugin.prototype );