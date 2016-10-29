function showText() {
  return function(){
    document.getElementById('text')
      .style.display = 'inline';
    document.getElementById('more')
      .style.display = 'none';
  }
}