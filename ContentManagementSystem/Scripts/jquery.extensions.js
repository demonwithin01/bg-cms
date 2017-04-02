( function ( $ )
{
    $.prototype.appendThen = function ( content, callback )
    {
        this.append( content );

        var $this = this;

        this.get( 0 ).offsetHeight;

        callback.call( this );

        return this;
    }

    $.prototype.appendRender = function ( content )
    {
        this.each( function ( index, element )
        {
            $( element ).append( content );

            element.offsetHeight;
        } )

        return this;
    }

} )( jQuery );