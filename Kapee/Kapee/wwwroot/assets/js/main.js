$(document).ready(function () {


    // Fashion corusel start
    if ($("#fashion").length) {
        $('#fashion .slider .owl-carousel').owlCarousel({
            items: 1,
            dots: true,
            loop: true,
            nav: true,
            mouseDrag: false,
            autoplay: true,
            autoplayTimeout: 5000,
        })
    }


    // category-slider corusel start
    if ($("#category-sliders").length) {
        $('#category-sliders .category-slider-content .owl-carousel').owlCarousel({
            dots: true,
            loop: false,
            nav: true,
            mouseDrag: true,
            responsive: {
                0: {
                    items: 2
                },
                600: {
                    items: 5
                },
                1000: {
                    items: 10
                }
            }
        })
    }
    
    
    // Collection corusel start
    if ($("#collection").length) {
        $('#collection .slider .owl-carousel').owlCarousel({
            margin: 30,
            mouseDrag: true,
            responsive: {
                0: {
                    items: 1
                },
                500: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        })
    }
     

    // Products corusel start
    if ($("#products").length) {
        $('#products .slider .owl-carousel').owlCarousel({
            dots: false,
            loop: false,
            nav: true,
            mouseDrag: true,
            responsive: {
                0: {
                    items: 2
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 4
                }
            }
        })

        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
          })
    }

    // product color change
    $(".product-color").click(function(){
        $(this).addClass("active");
        $(this).siblings().removeClass("active");
        console.log($(this).attr("data-id"));
        $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).removeClass("hide-img");
        $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).siblings().addClass("hide-img");
    })

    // product size change
    $(".product-size").click(function(){
        $(this).addClass("active");
        $(this).siblings().removeClass("active");
    })

    
    // Category corusel start
    if ($("#category").length) {
        $('#category .category-content .owl-carousel').owlCarousel({
            dots: false,
            loop: false,
            nav: true,
            mouseDrag: true,
            autoplay: false,
            responsive: {
                0: {
                    items: 2
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 4
                }
            }
        })
    }
    

    // Customer corusel start
    if ($("#customer").length) {
        $('#customer .customer-testimonial .owl-carousel').owlCarousel({
            dots: true,
            loop: false,
            nav: true,
            mouseDrag: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        })
    }
    
    // News corusel start
    if ($("#news").length) {
        $('#news .news-content .owl-carousel').owlCarousel({
            margin: 30,
            dots: false,
            loop: false,
            nav: true,
            mouseDrag: true,
            autoplay: false,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        })
    }
    $( ".slider .owl-carousel .owl-prev").html('<i class="fas fa-angle-left"></i>');
    $( ".slider .owl-carousel .owl-next").html('<i class="fas fa-angle-right"></i>');


    // Brand corusel start
    if ($("#brand").length) {
        $('#brand .owl-carousel').owlCarousel({
            margin: 30,
            dots: false,
            loop: false,
            nav: true,
            mouseDrag: true,
            autoplay: false,
            responsive: {
                0: {
                    items: 2
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 6
                }
            }
        })
    }
    $( ".slider .owl-carousel .owl-prev").html('<i class="fas fa-angle-left"></i>');
    $( ".slider .owl-carousel .owl-next").html('<i class="fas fa-angle-right"></i>');


    //  Header Scroll start 
    if($("#header-serch").length){
        $(window).scroll(function (e) { 
          e.preventDefault();
          let scroll = $(window).scrollTop();
          if(scroll > 100){
            $("#header-serch").addClass("show");
          }
          else{
            $("#header-serch").removeClass("show");
          }
        });
       }


    //  Header Logo Scroll start 
  if($(".logo").length){
    $(window).scroll(function (e) { 
      e.preventDefault();
      let scroll = $(window).scrollTop();
      if(scroll > 100){
        $(".logo").addClass("show");
      }
      else{
        $(".logo").removeClass("show");
      }
    });
   }

   //  Header header-account-heart-cart Scroll start 
   if($(".header-account-heart-cart").length){
    $(window).scroll(function (e) { 
      e.preventDefault();
      let scroll = $(window).scrollTop();
      if(scroll > 100){
        $(".header-account-heart-cart").addClass("show");
        if(window.innerWidth > 991.98){
            $("#header-serch .search").addClass("d-none");
        }
        
      }
      else{
        $(".header-account-heart-cart").removeClass("show");
        $("#header-serch .search").removeClass("d-none");
      }
    });
   }

   //  Header main-pages Scroll start 
   if($(".main-pages").length){
    $(window).scroll(function (e) { 
      e.preventDefault();
      let scroll = $(window).scrollTop();
      if(scroll > 100){
        $(".main-pages").addClass("show");
        if(window.innerWidth < 991.98){
            $(".header-account").addClass("d-none");
            $(".header-heart").addClass("d-none");
            $(".logo-mobil").addClass("d-none");
            $(".search").addClass("onscrol");
        }
        if(window.innerWidth < 767.98){
            $(".logo-mobil a").addClass("d-none");
            $(".header-account a").addClass("d-none");
            $(".header-heart a").addClass("d-none");
            $(".cart-icon").addClass("d-none");
        }
      }
      else{
        $(".main-pages").removeClass("show");
        if(window.innerWidth < 991.98){
            $(".header-account").removeClass("d-none");
            $(".header-heart").removeClass("d-none");
            $(".logo-mobil").removeClass("d-none");
            $(".search").removeClass("onscrol");
        }
        if(window.innerWidth < 767.98){
            $(".logo-mobil a").removeClass("d-none");
            $(".header-account a").removeClass("d-none");
            $(".header-heart a").removeClass("d-none");
            $(".cart-icon").removeClass("d-none");
        }
      }
    });
   }

    
   // Back-to-top start
 if($(".back-to-top").length){
    $(window).scroll(function (e) { 
      e.preventDefault();
      let scroll = $(window).scrollTop();
      if(scroll > 100){
        $(".back-to-top").addClass("show");
      }
      else{
        $(".back-to-top").removeClass("show");
      }
    });
   }

   //  WowAnimation Plugin
 function wowAnimation() {
    var wow = new WOW({
        boxClass: 'wow',
        animateClass: 'animated',
        offset: 0,
        mobile: false,
        live: true
    });
    wow.init();
 }
 $(window).on('load', function () {
  wowAnimation();
  });


 //Header responsive   
 $(".mobile-navbar a i").click(function(){
      $("#left-sidebar .mobile-menu").addClass("open");
      $(".bg-black").addClass("d-block")
      $("body").css("overflow","hidden")
 })
 $("#left-sidebar .mobile-menu .menu-header a .fa-angle-right").click(function(){
    $("#left-sidebar .mobile-menu").removeClass("open");
    $(".bg-black").removeClass("d-block")
    $("body").css("overflow","scroll")
 })

 $("#left-sidebar .mobile-primary-menu .main-munu .menu-btn i").click(function(){
      if($(this).hasClass("fa-plus")){
        $(this).removeClass("fa-plus").addClass("fa-minus");
        $(this).parent().next().slideToggle("slow");
      }
      else{
        $(this).removeClass("fa-minus").addClass("fa-plus");
        $(this).parent().next().slideToggle("slow");
        

      }
  })

  $("#left-sidebar .mobile-primary-menu .main-munu .menu-buton i").click(function(){
    if($(this).hasClass("fa-plus")){
      $(this).removeClass("fa-plus").addClass("fa-minus");
      $(this).parent().next().slideToggle("slow");
    }
    else{
      $(this).removeClass("fa-minus").addClass("fa-plus");
      $(this).parent().next().slideToggle("slow");

    }
})

 $(".mobile-category-menu .main-menu .menu-item i").click(function(){
     if($(this).hasClass("fa-plus")){
         $(this).removeClass("fa-plus").addClass("fa-minus");
         $(".mobile-category-menu .main-menu .menu-item .sub-menu").removeClass("d-none");
     }
     else{
        $(this).removeClass("fa-minus").addClass("fa-plus");
        $(".mobile-category-menu .main-menu .menu-item .sub-menu").addClass("d-none");
     }
 })

 $("#left-sidebar .mobile-menu .mobile-nav-tabs .primary").click(function(){
     $(this).addClass("active");
     $(this).siblings().removeClass("active");
    //  $(this).attr("data-id")
    if($(".mobile-primary-menu").attr("data-id") == $(this).attr("data-id")){
        $(".mobile-category-menu").addClass("d-none");
        $(".mobile-primary-menu").removeClass("d-none");
    }
    if($(".mobile-category-menu").attr("data-id") == $(this).attr("data-id")){
        $(".mobile-primary-menu").addClass("d-none");
        $(".mobile-category-menu").removeClass("d-none");
    }
    console.log($(".mobile-category-menu").attr("data-id") == $(this).attr("data-id"));
 })

})




