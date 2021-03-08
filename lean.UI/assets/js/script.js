$(document).ready(function () {
    // web lang
    if ($("html").attr("dir") == "rtl") {
        var dir_lang = true;
    } else {
        var dir_lang = false;
    }

    // open search popup
    $(".search-box i").click(function () {
        $(".search-box-pop").addClass("open-pop-up");
        $("body").addClass("body-over");
    });
    $(".close-pop-botton span").click(function () {
        $(".search-box-pop").removeClass("open-pop-up");
        $("body").removeClass("body-over");
    });




    // mobile-menu
    $(".menu-icone-box i").click(function () {
        $(".mobile-menu").addClass("opne-mobile-menu");
        $("body").addClass("body-over");
        $(".over-lay").show();
    });
    $(".mobile-menu .close-menu i , .over-lay").click(function () {
        $(".mobile-menu").removeClass("opne-mobile-menu");
        $("body").removeClass("body-over");
        $(".over-lay").hide();
    });




    // intro-slider
    $(".intro-slider").slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        outhight: true,
        prevArrow: "<div class='circle-arrow devo-right'><i class='fas fa-angle-right'></i></div>",
        nextArrow: "<div class='circle-arrow devo-left'><i class='fas fa-angle-left'></i></div>",
        autoplaySpeed: 2000,
        rtl: dir_lang,
        autoplay: false,
        dots: true,
        arrows: true,
    });


    
    // benefits-slider
    $(".benefits-slider").slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        outhight: true,
        prevArrow: "<div class='circle-arrow devo-right'><i class='fas fa-angle-right'></i></div>",
        nextArrow: "<div class='circle-arrow devo-left'><i class='fas fa-angle-left'></i></div>",
        autoplaySpeed: 2000,
        rtl: dir_lang,
        autoplay: true,
        dots: false,
        arrows: true,
        responsive: [
            {
              breakpoint: 1220,
              settings: {
                slidesToShow: 2,
                slidesToScroll: 1
              }
            },
            {
              breakpoint: 992,
              settings: {
                slidesToShow: 2,
                slidesToScroll: 1
              }
            },
            {
              breakpoint: 772,
              settings: {
                slidesToShow: 1,
                slidesToScroll: 1
              }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
          ]
    });



    // pop-up-portfoli
    $(".portfolioPage-section .portfoli-box .portfoli-Boxcontent .portfoli-discription .project-link").click(function () {
        $(".pop-up-portfoli").addClass("pop-up-portfoli-opne");
        const popSrc = $(this).parent(".portfoli-discription").parent(".portfoli-Boxcontent").parent(".portfoli-box").attr("data-link");
        $(".ifream-pop-up-portfoli").attr("src", popSrc);
        $("body").addClass("body-over");
    });

    $(".pop-up-portfoli .close-pop").click(function () {
        $(".pop-up-portfoli").removeClass("pop-up-portfoli-opne");
        $(".ifream-pop-up-portfoli").attr("src", "");
        $("body").removeClass("body-over");
    });



    // niceSelect
    $(".select-box").niceSelect();


    
    // aos
    AOS.init({
        duration: 1000
    });
});
