$(document).ready(function () {


    // register customer vender
    $("#register .main-content .register-right .form-check .vender").click(function () {
        $("#register .main-content .register-right .vender-form").removeClass("d-none");
        $("#register .main-content .register-right .user-form").addClass("d-none");
    })

    $("#register .main-content .register-right .form-check .customer").click(function () {
        $("#register .main-content .register-right .vender-form").addClass("d-none");
        $("#register .main-content .register-right .user-form").removeClass("d-none");
    })

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
    

    // Brand corusel start
    if ($("#brand").length) {
        $('#brand .owl-carousel').owlCarousel({
            margin: 30,
            dots: false,
            loop: false,
            nav: true,
            mouseDrag: true,
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
            $("#header-serch .header-heart a span").addClass("user-wishlist-response");
        }
        
      }
      else{
        $(".header-account-heart-cart").removeClass("show");
          $("#header-serch .search").removeClass("d-none");
          $("#header-serch .header-heart a span").removeClass("user-wishlist-response");
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
            
            $("#product-info .accordition .card .card-header h5 a").click(function () {
                    
                  if($(this).children().hasClass("fa-angle-down")){
                        $("#product-info .accordition .card .card-header h5 a .fa-angle-up").removeClass("fa-angle-up").addClass("fa-angle-down")
                        $(this).children().removeClass("fa-angle-down").addClass("fa-angle-up");
                    }
                    else{
                        $(this).children().removeClass("fa-angle-up").addClass("fa-angle-down");
                    }
            })
        }
        if(window.innerWidth < 767.98){
            $(".logo-mobil a").addClass("d-none");
            $(".header-account a").addClass("d-none");
            $(".header-heart a").addClass("d-none");
            $(".cart-icon").addClass("d-none");

            $("#product-info .accordition .card .card-header h5 a").click(function () {
                    
                if($(this).children().hasClass("fa-angle-down")){
                      $("#product-info .accordition .card .card-header h5 a .fa-angle-up").removeClass("fa-angle-up").addClass("fa-angle-down")
                      $(this).children().removeClass("fa-angle-down").addClass("fa-angle-up");
                  }
                  else{
                      $(this).children().removeClass("fa-angle-up").addClass("fa-angle-down");
                  }
            })
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

        //  Product Detail start
        if ($(".product-sync-init").length) {
            $(".product-sync-init").slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: false,
                draggable: false,
                arrows: false,
                dots: false,
                fade: true,
                asNavFor: ".product-sync-nav",
            });

            $(".product-sync-nav").slick({
                dots: true,
                arrows: true,
                infinite: false,
                prevArrow: '<button class="next slick-prev"><i class="fas fa-angle-left"></i></button>',
                nextArrow: '<button class="prev slick-next"><i class="fas fa-angle-right"></i></button>',
                slidesToShow: 4,
                slidesToScroll: 1,
                asNavFor: ".product-sync-init",
                focusOnSelect: true,
                draggable: false,
            });
        }

        //Product photo zoom   
        if ($("#product-single .product-slider .product-sync-init .single-product .product-thumb").length) {
            $("#product-single .product-slider .product-sync-init .single-product .product-thumb").zoom();
        }
  

       //Product small photo active class border   
       $("#product-single .product-slider .product-sync-nav img").click(function(){
           $(".product-thumb .active").removeClass("active");
           $(this).addClass("active");
        })

        // product color change
       $(".product-color").click(function(){
           $(this).addClass("active");
           $(this).siblings().removeClass("active");
           console.log($(this).parents().parents().parent().find(".product-sync-init .single-product .product-thumb img"));
           $(this).parents().parents().parent().find(`.product-sync-init .single-product .product-thumb img[data-id=${$(this).attr("data-id")}]`).removeClass("hide-img");
           $(this).parents().parents().parent().find(`.product-sync-init .single-product .product-thumb img[data-id=${$(this).attr("data-id")}]`).siblings().addClass("hide-img");
           $(this).parents().parents().parent().find(`.product-sync-nav .single-product .product-thumb img[data-id=${$(this).attr("data-id")}]`).removeClass("hide-img");
           $(this).parents().parents().parent().find(`.product-sync-nav .single-product .product-thumb img[data-id=${$(this).attr("data-id")}]`).siblings().addClass("hide-img");
        })

       // product size change
       $(".product-size").click(function(){
           console.log($(this).parents().next().find(".price"));
           $(this).addClass("active");
           $(this).siblings().removeClass("active");
           $(this).parents().next().find(`.price[data-id = ${$(this).attr("data-id")}]`).removeClass("hide-size");
           $(this).parents().next().find(`.price[data-id = ${$(this).attr("data-id")}]`).siblings().addClass("hide-size");
        })

        // Related products corusel start
        if ($("#related-product").length) {
        $('#related-product .owl-carousel').owlCarousel({
                 dots: true,
                 loop: true,
                 nav: true,
                 mouseDrag: true,
                 autoplay: true,
                 autoplayTimeout: 5000,
                 responsive: {
                    0: {
                        items: 2
                    },
                    600: {
                        items: 3
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

        // Recently view corusel start
        if ($("#recently-view").length) {
            $('#recently-view .owl-carousel').owlCarousel({
                     dots: false,
                     loop: false,
                     nav: true,
                     mouseDrag: true,
                     responsive: {
                        0: {
                            items: 2
                        },
                        600: {
                            items: 3
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


        // related product color change
        $(".product-color").click(function(){
            $(this).addClass("active");
            $(this).siblings().removeClass("active");
            console.log($(this).attr("data-id"));
            $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).removeClass("hide-img");
            $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).siblings().addClass("hide-img");
        })

        // related product size change
        $(".product-size").click(function(){
            $(this).addClass("active");
            $(this).siblings().removeClass("active");
        })


        // recently view color change
        $(".product-color").click(function(){
            $(this).addClass("active");
            $(this).siblings().removeClass("active");
            console.log($(this).attr("data-id"));
            $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).removeClass("hide-img");
            $(this).parents(".product-group").find(`.product-img a img[data-id=${$(this).attr("data-id")}]`).siblings().addClass("hide-img");
        })

         // recently view size change
         $(".product-size").click(function(){
            $(this).addClass("active");
            $(this).siblings().removeClass("active");
         })

        //  category-detail
        $("#main-page .product-categories .categories-items .category-item a i").click(function(e){
            e.preventDefault();
            if($(this).hasClass("fa-angle-down")){
                $(this).removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).parent().next().next().removeClass("d-none");
               }
             else{
                $(this).removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).parent().next().next().addClass("d-none");
             
            }
        })
        $("#main-page .color-filter .color-filter-list .color-filter-item a .product-color span").hover(function(){
            $(function () {
                $('[data-toggle="tooltip"]').tooltip()
            })
        })
        $("#main-page .product-categories h2").click(function(){
            console.log();
            if($("#main-page .product-categories h2 i").hasClass("fa-angle-up")){
                $("#main-page .product-categories h2 i").removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).next().addClass("d-none");
            }
            else{
                $("#main-page .product-categories h2 i").removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).next().removeClass("d-none");
            }
        })
        $("#main-page .price-filter h2").click(function(){
            console.log();
            if($("#main-page .price-filter h2 i").hasClass("fa-angle-up")){
                $("#main-page .price-filter h2 i").removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).next().addClass("d-none");
            }
            else{
                $("#main-page .price-filter h2 i").removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).next().removeClass("d-none");
            }
        })
        $("#main-page .color-filter h2").click(function(){
            console.log();
            if($("#main-page .color-filter h2 i").hasClass("fa-angle-up")){
                $("#main-page .color-filter h2 i").removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).next().addClass("d-none");
            }
            else{
                $("#main-page .color-filter h2 i").removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).next().removeClass("d-none");
            }
        })
        $("#main-page .size-filter h2").click(function(){
            console.log();
            if($("#main-page .size-filter h2 i").hasClass("fa-angle-up")){
                $("#main-page .size-filter h2 i").removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).next().addClass("d-none");
            }
            else{
                $("#main-page .size-filter h2 i").removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).next().removeClass("d-none");
            }
        })
        $("#main-page .star-filter h2").click(function(){
            console.log();
            if($("#main-page .star-filter h2 i").hasClass("fa-angle-up")){
                $("#main-page .star-filter h2 i").removeClass("fa-angle-up").addClass("fa-angle-down");
                $(this).next().addClass("d-none");
            }
            else{
                $("#main-page .star-filter h2 i").removeClass("fa-angle-down").addClass("fa-angle-up");
                $(this).next().removeClass("d-none");
            }
        })
 
})




