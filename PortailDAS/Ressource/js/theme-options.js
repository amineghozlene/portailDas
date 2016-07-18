/* ::
:::::
::::: Theme 		: JETS
::::: Theme URI		: http://funcoders.com/theme/Jets
:::::
::::: File 			: theme-options.js
::::: Description	: Scripts for options widget
:::::
:: */

$(document).ready(function () {

	/*  *********  */
	/*  SHOW/HIDE  */
	/*  *********  */
	$('#options-toggle').click(function () {
		$('#theme-options').toggleClass('open');
		return false;
	});

	/*  ************  */
	/*  SAVE OPTIONS  */
	/*  ************  */
	$('#theme-options select').change(function() {

		var name 	= $(this).attr('name'),
			value  	= $(this).val(),
			target 	= $(this).attr('data-target');

		var clear_css = '';
		$("option", this).each(function() {
			if (value !== $(this).val()) clear_css += ' '+$(this).val();
		});

		$.cookie(name, value);

		if (target) {
			if (value !== 'default') {
				$(target).removeClass(clear_css).addClass(value);
			} else {
				$(target).removeClass(clear_css);
			}
		}

		if ($(this).attr('data-refresh') == "true")
			window.location.reload();

	});

	$("#theme-options .option-content a").click(function() {

		var name 	= $(this).closest("ul").attr("data-name"),
			value 	= $(this).attr("href");

		if (name == "bg") {

			var bgStyle;
			if ( value.indexOf('pat-') > -1 ) {
				bgStyle = {
					"background-image" : "url('img/backgrounds/pattern/"+value.replace('pat-', '')+"/"+value.replace('pat-', '')+".png')",
					"background-attachment": "scroll",
					"background-size": "auto",
					"background-repeat": "repeat repeat"
				}
			} else  {
				bgStyle = {
					"background-image" : "url('img/backgrounds/img/"+value.replace('bg-', '')+"/background.jpg')",
					"background-attachment": "fixed",
					"background-size": "cover",
					"background-repeat": "no-repeat no-repeat"
				}
			}
			$("body").removeAttr('style').css(bgStyle);

		} else if (name == "color") {

			$('#layout-color').attr('href','css/color/'+value+'.css');
		}

		$("ul[data-name="+name+"] a").removeClass("active");
		$(this).addClass("active");
		$.cookie(name, value);

		return false;
	});

	$("#bg-changer a").click(function() {
		$(this).addClass("active").siblings().removeClass("active");

		$("#bg-changer-target").removeClass("container-dark container-light").addClass($(this).attr("href"));

		return false;
	});

	$("#main-menu a, #mobile-menu a").click(function(event){

		if ($(this).attr("href") !== "#") {

			var name 	= $(this).data('name'),
				value  	= $(this).attr('href');

			if (name) {
				event.preventDefault();
				$.cookie(name, value);
				window.location.reload();
			}

		}
	});

});