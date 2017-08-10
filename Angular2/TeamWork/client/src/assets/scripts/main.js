$(window).on('load', function () {
  function setMainHeight () {
    let windowHeight = $(window).height()
    let headerHeight = $('nav').height()
    let footerHeight = $('footer').height()
    let height = windowHeight - headerHeight - footerHeight - 23
    $('main').css('min-height', height)
  }

  $('#menu-links li').click(function () {
    $('#menu-links li').removeClass('active')
    $(this).closest('li').addClass('active')
    setMainHeight()
  })

  setMainHeight()
  $(window).on('resize', setMainHeight)
})