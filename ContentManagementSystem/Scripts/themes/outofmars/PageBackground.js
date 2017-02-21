var outofmars;
(function (outofmars) {
    var Light = (function () {
        function Light(background, x, y, size, life, drawInterval) {
            this._background = background;
            this._x = x;
            this._y = y;
            this._size = size;
            this._life = life;
            this._drawInterval = drawInterval;
            var time = Math.random();
            var timeTillInitialFlicker = Math.random();
            do {
                time *= 10;
            } while (time < 10);
            while (timeTillInitialFlicker < 0.01) {
                timeTillInitialFlicker *= 10;
            }
            this._timeBetweenFlickers = (3 + time) * 1000;
            this._timeTillNextFlicker = this._timeBetweenFlickers * timeTillInitialFlicker;
            this._minimumBlurRadius = 0.4;
            this._maximumBlurRadius = 0.6;
            this._direction = 1;
            this._blurRadius = this._minimumBlurRadius + life;
            this._flickerRate = 0.01 + Math.random() / 10;
            this._flickerRate = 500;
        }
        Light.prototype.draw = function (context) {
            //var gradient = context.createRadialGradient( this._x, this._y, 2, this._x, this._y, this._size );
            var g = context.createLinearGradient(0, 0, 1, 1);
            //context.beginPath();
            //context.arc( this._x, this._y, this._size, 0, Math.PI * 2, true );
            //context.shadowBlur = 20;
            //context.shadowColor = "#222";
            this._timeTillNextFlicker -= this._drawInterval;
            if (this._timeTillNextFlicker < 0) {
                var t = Math.abs(this._timeTillNextFlicker);
                var p = (t / this._flickerRate) * 100;
                if (t > this._flickerRate)
                    p = 200 - p;
                var c = 155 + Math.round(p);
                context.fillStyle = "rgb(" + c + "," + c + "," + c + ")";
                if (this._timeTillNextFlicker < -(this._flickerRate * 2)) {
                    this._timeTillNextFlicker = this._timeBetweenFlickers;
                }
            }
            else {
                context.fillStyle = "rgb(155, 155, 155)";
            }
            context.fillRect(this._x, this._y, 2, 2);
            //gradient.addColorStop( 0, "rgba( 255, 255, 255, 1 )" );
            //gradient.addColorStop( 0.01, "rgba( 255, 255, 255, " + this._blurRadius + " )" );
            //gradient.addColorStop( 1, "rgba( 255, 255, 255, 0 )" );
            //context.fillStyle = gradient;
            //context.fill();
        };
        return Light;
    }());
    var PageBackground //extends site.plugin
     = (function () {
        function PageBackground //extends site.plugin
            () {
            //super();
            this._timeBetweenRenders = 100;
            var $canvas = $("<canvas id=\"pageBackground\" style=\"position: fixed; top: 0; left: 0;\">");
            $("body").prepend($canvas);
            this._canvas = $canvas.get(0);
            this._context = this._canvas.getContext("2d");
            this._lights = new Array();
        }
        PageBackground //extends site.plugin
        .prototype.onWindowResize = function () {
            this._canvas.width = window.innerWidth;
            this._canvas.height = window.innerHeight;
            this._redraw();
            console.log("resize Background");
        };
        PageBackground //extends site.plugin
        .prototype.onMainContentScroll = function () {
            console.log("scroll Background");
        };
        PageBackground //extends site.plugin
        .prototype.initialise = function () {
            this._canvas.width = $("body").width();
            this._canvas.height = window.innerHeight;
            var horizontalSegments = 25;
            var verticalSegments = 18;
            var segmentWidth = this._canvas.width / horizontalSegments;
            var segmentHeight = this._canvas.height / verticalSegments;
            for (var i = 0; i < horizontalSegments; i++) {
                for (var j = 0; j < verticalSegments; j++) {
                    var x = Math.random();
                    var y = Math.random();
                    while (x < 0.01) {
                        x *= 10;
                    }
                    while (y < 0.01) {
                        y *= 10;
                    }
                    x = (x * segmentWidth) + (i * segmentWidth);
                    y = (y * segmentHeight) + (j * segmentHeight);
                    this._lights.push(new Light(this, x, y, 4, Math.random(), this._timeBetweenRenders));
                }
            }
            this._redraw();
            var that = this;
            this._drawInterval = setInterval(function () { that._redraw(); }, this._timeBetweenRenders);
        };
        PageBackground //extends site.plugin
        .prototype._redraw = function () {
            var x = 0;
            var y = 0;
            var w = this._canvas.width;
            var h = this._canvas.height;
            this._context.clearRect(x, y, w, h);
            this._context.fillStyle = "rgba(0,0,0,0)";
            this._context.fillRect(x, y, w, h);
            for (var i = 0; i < this._lights.length; i++) {
                this._lights[i].draw(this._context);
            }
        };
        return PageBackground //extends site.plugin
        ;
    }());
    outofmars.PageBackground //extends site.plugin
     = PageBackground //extends site.plugin
    ;
})(outofmars || (outofmars = {}));
//# sourceMappingURL=PageBackground.js.map