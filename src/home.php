<div class="container">
  <div class="vertical-center-page"></div>
  <h1 id="hero"></h1>

  <script>
    $(document).ready(function() {
      new TypeIt('#hero', {
        speed: 90,
        startDelay: 300
      })
      .options({speed: 50})
      .type("Ryan Rickgauer's Blog")
      .go();

    });
  </script>
</div>
