$(document).ready(function() {
    $("#sliderHotProducts").flexisel({
        visibleItems: 4,
        itemsToScroll: 3,
        animationSpeed: 1000,
        infinite: true,
        navigationTargetSelector: null,
        autoPlay: true,
        autoPlaySpeed: 1500,
        pauseOnHover: true,
        autoPlaySpeed: 1500,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 480,
                visibleItems: 1,
                itemsToScroll: 1
            },
            landscape: {
                changePoint: 640,
                visibleItems: 2,
                itemsToScroll: 2
            },
            tablet: {
                changePoint: 768,
                visibleItems: 3,
                itemsToScroll: 3
            }
        }
    })
    $("#flexiselBrand").flexisel({
        visibleItems: 4,
        itemsToScroll: 3,
        animationSpeed: 1000,
        infinite: true,
        navigationTargetSelector: null,
        autoPlay: true,
        autoPlaySpeed: 3000,
        pauseOnHover: true,
        autoPlaySpeed: 3000,
        responsiveBreakpoints: {
            portrait: {
                changePoint: 480,
                visibleItems: 1,
                itemsToScroll: 1
            },
            landscape: {
                changePoint: 640,
                visibleItems: 2,
                itemsToScroll: 2
            },
            tablet: {
                changePoint: 768,
                visibleItems: 3,
                itemsToScroll: 3
            }
        }
    })
    $(".show_more_1").slice(0, 8).show(); //show 4 div
    $(".loadMore").on("click", function() {

        //var a = ('.show_button:not([style*="display: none"])').length;
        $(".show_more_1:hidden").slice(0, 8).slideDown(); //showing hidden div
        if ($('.show_more_1:hidden').length == 0) {
            $(".loadMore").remove();
        }
    })
    $(".show_more_2").slice(0, 8).show(); //show 4 div
    $(".loadMore1").on("click", function() {

        //var a = ('.show_button:not([style*="display: none"])').length;
        $(".show_more_2:hidden").slice(0, 8).slideDown(); //showing hidden div
        if ($('.show_more_2:hidden').length == 0) {
            $(".loadMore1").remove();
        }
    })

})