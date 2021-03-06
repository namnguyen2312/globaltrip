$(document).ready(function() {
 var mySwiper = new Swiper ('.main-slider', {
    // Optional parameters
    loop: true,
    // If we need pagination
    autoplay: {
        delay: 10000,
        disableOnInteraction: false,
      },
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
    },

    // Navigation arrows
    // navigation: {
    //   nextEl: '.swiper-button-next',
    //   prevEl: '.swiper-button-prev',
    // }
  });
  var mySwiper1 = new Swiper ('.swiper-container', {
    // Optional parameters
    loop: true,
    // If we need pagination
    autoplay: {
        delay: 10000,
        disableOnInteraction: false,
      },

    // Navigation arrows
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    }
  });

  //mobile-menu
  $("#my-menu").mmenu();
  var API = $("#my-menu").data( "mmenu" );
  $(".mobile-menu .text-left #primary-menu").click(function() {
    API.open();
  });

  //pagination: change active class
  $(".pagination1 li").click(function() {
    $('.pagination1 li.active').removeClass('active');
    $(this).addClass('active');
  });

  $("#primary-menu li").click(function (){
    $("#primary-menu li.active").removeClass('active');
    $(this).addClass('active');
  });
  //search button
  var isOpen = false;
  $(".icon-search-menu .wicon").click(function(){
      // $("div.hide-search").removeClass('hide-search').addClass('unhide-search');
    if(isOpen == false){
      $("#searchBox").removeClass('hide-search').addClass('unhide-search');
      // inputBox.focus();
      isOpen = true;
    } else {
      $("#searchBox").removeClass('unhide-search').addClass('hide-search');
      // inputBox.focusout();
      isOpen = false;
    }
  });
  $(document).click(function (e)
  {
    var container = $(".icon-search-menu .wicon")
    if (!container.is(e.target) && container.has(e.target).length === 0)
    {
      // $('#searchbox').hide();
      $("#searchBox").removeClass('unhide-search').addClass('hide-search');
    }
  });

  var isOpen = false;
  $(".icon-search-menu .wicon1").click(function(){
      // $("div.hide-search").removeClass('hide-search').addClass('unhide-search');
    if(isOpen == false){
      $("#searchBox1").removeClass('hide-search').addClass('unhide-search');
      // inputBox.focus();
      isOpen = true;
    } else {
      $("#searchBox1").removeClass('unhide-search').addClass('hide-search');
      // inputBox.focusout();
      isOpen = false;
    }
  });
  $(document).click(function (e)
  {
    var container = $(".icon-search-menu .wicon1")
    if (!container.is(e.target) && container.has(e.target).length === 0)
    {
      // $('#searchbox').hide();
      $("#searchBox1").removeClass('unhide-search').addClass('hide-search');
    }
  });


  //update date tour
  $('#datetimepicker4').datetimepicker({
      format: 'DD/MM/YYYY'
    });
  $('#datetimepicker5').datetimepicker({
      format: 'DD/MM/YYYY'
    });

  //accordion menu
  var accordionsMenu = $('.cd-accordion-menu');

  if( accordionsMenu.length > 0 ) {

    accordionsMenu.each(function(){
      var accordion = $(this);
      //detect change in the input[type="checkbox"] value
      accordion.on('change', 'input[type="checkbox"]', function(){
        var checkbox = $(this);
        console.log(checkbox.prop('checked'));
        ( checkbox.prop('checked') ) ? checkbox.siblings('ul').attr('style', 'display:none;').slideDown(300) : checkbox.siblings('ul').attr('style', 'display:block;').slideUp(300);
      });
    });
  }

  var accordionsMenu1 = $('.cd-accordion-menu1');

  if( accordionsMenu1.length > 0 ) {

    accordionsMenu1.each(function(){
      var accordion1 = $(this);
      //detect change in the input[type="checkbox"] value
      accordion1.on('change', 'input[type="checkbox"]', function(){
        var checkbox1 = $(this);
        console.log(checkbox1.prop('checked'));
        ( checkbox1.prop('checked') ) ? checkbox1.siblings('ul').attr('style', 'display:none;').slideDown(300) : checkbox1.siblings('ul').attr('style', 'display:block;').slideUp(300);
      });
    });
  }

  //validation

  $("#customerForm").validate({
      rules: {
        fullname: {
          required: true,
          minlength: 6
        },
        email: {
          required: true,
          email: true
        },
        phone: {
          required: true,
          minlength: 6
        }
      },
      messages: {
        username: {
          required: "Vui l??ng nh???p h??? t??n",
          minlength: "vui l??ng nh???p h??? t??n ?????y ?????"
        },
        phone: {
          required: "Vui l??ng nh???p s??? ??i???n thoai",
          minlength: "Vui l??ng nh???p ch??nh x??c s??? ??i???n tho???i"
        },
        email: "Vui l??ng nh???p ch??nh x??c email"
      }
    });
});

