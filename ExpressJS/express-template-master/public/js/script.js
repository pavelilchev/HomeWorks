$(window).on('load', function () {
  $('#menu-links li').click(function () {
    $('#menu-links li').removeClass('active')
    $(this).closest('li').addClass('active')
  })

  setTimeout(function () {
    $('#success-msg').delay(1000).fadeOut(300)
  }, 3000)

  $('.msg').click(function () {
    $(this).fadeOut(300)
  })

  setMainHeight()

  $(window).on('resize', setMainHeight)

  function setMainHeight () {
    let windowHeight = $(window).height()
    let headerHeight = $('header').height()
    let footerHeight = $('footer').height()
    let mainHeight = Math.max($('main #wrapper').height(), (windowHeight - headerHeight - footerHeight - 25))
    $('main').height(mainHeight)
  }
})
