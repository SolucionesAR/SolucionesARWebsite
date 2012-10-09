/*! Copyright (c) 2011 Brandon Aaron (http://brandonaaron.net)
 * Licensed under the MIT License (LICENSE.txt).
 *
 * Thanks to: http://adomas.org/javascript-mouse-wheel/ for some pointers.
 * Thanks to: Mathias Bank(http://www.mathias-bank.de) for a scope bug fix.
 * Thanks to: Seamus Leahy for adding deltaX and deltaY
 *
 * Version: 3.0.6
 * 
 * Requires: 1.2.2+
 */

(function($) {

var types = ['DOMMouseScroll', 'mousewheel'];

if ($.event.fixHooks) {
    for ( var i=types.length; i; ) {
        $.event.fixHooks[ types[--i] ] = $.event.mouseHooks;
    }
}

$.event.special.mousewheel = {
    setup: function() {
        if ( this.addEventListener ) {
            for ( var i=types.length; i; ) {
                this.addEventListener( types[--i], handler, false );
            }
        } else {
            this.onmousewheel = handler;
        }
    },
    
    teardown: function() {
        if ( this.removeEventListener ) {
            for ( var i=types.length; i; ) {
                this.removeEventListener( types[--i], handler, false );
            }
        } else {
            this.onmousewheel = null;
        }
    }
};

$.fn.extend({
    mousewheel: function(fn) {
        return fn ? this.bind("mousewheel", fn) : this.trigger("mousewheel");
    },
    
    unmousewheel: function(fn) {
        return this.unbind("mousewheel", fn);
    }
});


function handler(event) {
    var orgEvent = event || window.event, args = [].slice.call( arguments, 1 ), delta = 0, returnValue = true, deltaX = 0, deltaY = 0;
    event = $.event.fix(orgEvent);
    event.type = "mousewheel";
    
    // Old school scrollwheel delta
    if ( orgEvent.wheelDelta ) { delta = orgEvent.wheelDelta/120; }
    if ( orgEvent.detail     ) { delta = -orgEvent.detail/3; }
    
    // New school multidimensional scroll (touchpads) deltas
    deltaY = delta;
    
    // Gecko
    if ( orgEvent.axis !== undefined && orgEvent.axis === orgEvent.HORIZONTAL_AXIS ) {
        deltaY = 0;
        deltaX = -1*delta;
    }
    
    // Webkit
    if ( orgEvent.wheelDeltaY !== undefined ) { deltaY = orgEvent.wheelDeltaY/120; }
    if ( orgEvent.wheelDeltaX !== undefined ) { deltaX = -1*orgEvent.wheelDeltaX/120; }
    
    // Add event and delta to the front of the arguments
    args.unshift(event, delta, deltaX, deltaY);
    
    return ($.event.dispatch || $.event.handle).apply(this, args);
}

})(jQuery);
$(document).ready(function() {
	
	//	SEPARATE JS

	$('.entry').jScrollPane();
	
	$('.jspVerticalBar').each(function(index, element) {
		var picwidth = $(this).prev(".jspPane").width();
		$(this).prev(".jspPane").css({ width:picwidth-20 });
	});
	
	$('.work_content .slides').cycle({ 
		fx:             'fade', 
		speed:          200, 
		cleartype:      true,
		cleartypeNoBg:  true,
		pager:           '.work_content .innernav',
		prev:           '.work_content .prev',
		next:           '.work_content .next',
		timeout:        0
	});


	//	Blog image slideshow
	$('.blog_content .post .image_content').cycle({ 
		fx:             'fade', 
		speed:          500, 
		cleartype:      true,
		cleartypeNoBg:  true,
		timeout:        5000, 
		next:           ".blog_content .post .image_content img"
	});
	
	//	Blog pagination
	$('.blog_content .posts').cycle({ 
		fx:             'fade', 
		speed:          200, 
		cleartype:      true,
		cleartypeNoBg:  true,
		pager:           '.blog_content .innernav',
		prev:           '.blog_content .prev',
		next:           '.blog_content .next',
		timeout:        0
	});

	$(".work_content li a").fancybox({
		padding: 0,
		openEffect : 'elastic',
		openSpeed  : 150,
		closeEffect : 'elastic',
		closeSpeed  : 100,
		closeClick : false,
		helpers : {
			title : {
				type : 'over'
			},
			overlay : {
				opacity : 0.40,
				css : {
					'background-color' : '#000'	
				}
			}
		}
	});
});
$(document).ready(function() {
	
	// Contact form
	$("#ajax-contact-form").submit(function(){
		var str = $(this).serialize();
		$.ajax({
		type: "POST",
		url: "contact/contact.php",
		data: str,
		success: function(msg){
			$("#note").ajaxComplete(function(event, request, settings){
				if(msg == 'OK'){
					result = '<div class="notification_ok">Your message has been sent. Thank you!</div>';
					$("#ajax-contact-form input, #ajax-contact-form textarea").hide();
				}else{
					result = msg;
				}
				$(this).html(result);
			});
		}
		});
		return false;
	});
});
