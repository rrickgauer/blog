<section id="top-navbar">
	<div class="container-fluid">
		<nav class="navbar navbar-toggleable-sm navbar-expand-sm navbar-dark">
			<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
				<ion-icon name="menu" class="custom-text-white"></ion-icon>
			</button>

			<!-- Links -->
			<div class="collapse navbar-collapse" id="navbarNav">
				<ul class="nav navbar-nav">
					<li class="nav-item nav-link-hover"><a class="nav-link" href="entries.php" id="entries-nav">Posts</a></li>

					<?php
					if (isset($_SESSION['loggedIn']) && $_SESSION['loggedIn'] == true) {
						printNewEditNavs();
					} else {
						printLoginNav();
					}

					?>




				</ul>
			</div>
		</nav>
	</div>
</section>

<?php

function printNewEditNavs() {
	echo "<li class=\"nav-item nav-link-hover\"><a class=\"nav-link\" href=\"new-entry.php\" id=\"new-entry-nav\">New Post</a></li>";
	echo "<li class=\"nav-item nav-link-hover\"><a class=\"nav-link\" href=\"edit-entry.php\" id=\"edit-entry-nav\">Edit Post</a></li>";
	echo "<li class=\"nav-item nav-link-hover\"><a class=\"nav-link\" href=\"logout.php\" id=\"logout-nav\">Logout</a></li>";
}


function printLoginNav() {
	echo "<li class=\"nav-item nav-link-hover\"><a class=\"nav-link\" href=\"login-page.php\" id=\"login-nav\">Login</a></li>";
}


?>
