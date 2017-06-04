$(window).on('load', function () {
  $('#menu-links li').click(function () {
    $('#menu-links li').removeClass('active')
    $(this).closest('li').addClass('active')
  })

  setTimeout(function() {
    $('#success-msg').delay(1000).fadeOut(300)
  }, 3000)

   $('.msg').click(function(){
     $(this).fadeOut(300)
   })
})
