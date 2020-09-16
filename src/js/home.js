
//////////
// main //
//////////
$(document).ready(function() {
  initTypeIt();
});


function initTypeIt() {
  new TypeIt('.custom-font', {
    speed: 50,
    startDelay: 900
  })
  .options({speed: 50})
  .go();
}