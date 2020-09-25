

This is a demo of my [auto-tables javascript library](https://github.com/rrickgauer/auto-tables)


<div class="container">

<ul class="nav nav-pills justify-content-center" id="project-pills-tab" role="tablist">
  <li class="nav-item">
    <a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#table-display" role="tab">Table</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#table-code" role="tab">View Code</a>
  </li>
</ul>


<div class="tab-content" id="pills-tabContent">

<!-- rendered html goes here -->
<div class="tab-pane fade show active" id="table-display" role="tabpanel">

<input type="text" class="form-control mb-3 tablesearch-input" data-tablesearch-table="#data-table"  placeholder="Search">


<div class="table-responsive">

<table id="data-table" class="table table-sm tablesort tablesearch-table">
  <thead><tr>
    <th data-tablesort-type="int">Index</th>
    <th data-tablesort-type="string">First name</th>
    <th data-tablesort-type="string">Last name</th>
    <th data-tablesort-type="string">Email</th>
    <th data-tablesort-type="string">Country</th>
    <th data-tablesort-type="date">Dob</th>
  </tr></thead>
  <tbody>
    <tr><td>1</td><td>Dreddy</td><td>Norgate</td><td>dnorgate0@java.com</td><td>Indonesia</td><td data-tablesort-value="19560309">03/09/1956</td></tr>
    <tr><td>2</td><td>Rodger</td><td>Parkins</td><td>rparkins1@imdb.com</td><td>Brazil</td><td data-tablesort-value="18810225">02/25/1881</td></tr>
    <tr><td>3</td><td>Udell</td><td>Treeby</td><td>utreeby2@xing.com</td><td>Bolivia</td><td data-tablesort-value="19690125">01/25/1969</td></tr>
    <tr><td>4</td><td>Marsiella</td><td>Ghelarducci</td><td>mghelarducci3@cpanel.net</td><td>Japan</td><td data-tablesort-value="19761016">10/16/1976</td></tr>
    <tr><td>5</td><td>Kerwinn</td><td>Dickey</td><td>kdickey4@cornell.edu</td><td>Thailand</td><td data-tablesort-value="19821004">10/04/1982</td></tr>
    <tr><td>6</td><td>Rani</td><td>Meatyard</td><td>rmeatyard5@twitpic.com</td><td>China</td><td data-tablesort-value="18980910">09/10/1898</td></tr>
    <tr><td>7</td><td>Bianka</td><td>Spellacy</td><td>bspellacy6@icq.com</td><td>United States</td><td data-tablesort-value="19120828">08/28/1912</td></tr>
    <tr><td>8</td><td>Dianna</td><td>Jouaneton</td><td>djouaneton7@samsung.com</td><td>Montenegro</td><td data-tablesort-value="19151204">12/04/1915</td></tr>
    <tr><td>9</td><td>Emlyn</td><td>Preator</td><td>epreator8@chicagotribune.com</td><td>Indonesia</td><td data-tablesort-value="19540313">03/13/1954</td></tr>
    <tr><td>10</td><td>Kellie</td><td>Leipelt</td><td>kleipelt9@columbia.edu</td><td>China</td><td data-tablesort-value="19761203">12/03/1976</td></tr>
    <tr><td>11</td><td>Trisha</td><td>Giorgioni</td><td>tgiorgionia@cloudflare.com</td><td>Bosnia and Herzegovina</td><td data-tablesort-value="19610730">07/30/1961</td></tr>
    <tr><td>12</td><td>Lyn</td><td>Gault</td><td>lgaultb@google.es</td><td>Portugal</td><td data-tablesort-value="19710320">03/20/1971</td></tr>
    <tr><td>13</td><td>Carolan</td><td>Redgrave</td><td>credgravec@twitpic.com</td><td>Argentina</td><td data-tablesort-value="19310912">09/12/1931</td></tr>
    <tr><td>14</td><td>Adler</td><td>Fasset</td><td>afassetd@sohu.com</td><td>Albania</td><td data-tablesort-value="19610515">05/15/1961</td></tr>
    <tr><td>15</td><td>Lucretia</td><td>Huxton</td><td>lhuxtone@pen.io</td><td>Colombia</td><td data-tablesort-value="18961117">11/17/1896</td></tr>
  </tbody>
</table>

</div>


</div>


<!-- code goes here -->
<div class="tab-pane fade" id="table-code" role="tabpanel">

<pre><code class="language-html">
<input type="text" class="tablesearch-input" data-tablesearch-table="#data-table" placeholder="Search">

<table id="data-table" class="tablesort tablesearch-table">
  <thead><tr>
    <th data-tablesort-type="int">Index</th>
    <th data-tablesort-type="string">First name</th>
    <th data-tablesort-type="string">Last name</th>
    <th data-tablesort-type="string">Email</th>
    <th data-tablesort-type="string">Country</th>
    <th data-tablesort-type="date">Dob</th>
  </tr></thead>
  <tbody>
    <tr><td>1</td><td>Dreddy</td><td>Norgate</td><td>dnorgate0@java.com</td><td>Indonesia</td><td data-tablesort-value="19560309">03/09/1956</td></tr>
    <tr><td>2</td><td>Rodger</td><td>Parkins</td><td>rparkins1@imdb.com</td><td>Brazil</td><td data-tablesort-value="18810225">02/25/1881</td></tr>
    <tr><td>3</td><td>Udell</td><td>Treeby</td><td>utreeby2@xing.com</td><td>Bolivia</td><td data-tablesort-value="19690125">01/25/1969</td></tr>
    <tr><td>4</td><td>Marsiella</td><td>Ghelarducci</td><td>mghelarducci3@cpanel.net</td><td>Japan</td><td data-tablesort-value="19761016">10/16/1976</td></tr>
    <tr><td>5</td><td>Kerwinn</td><td>Dickey</td><td>kdickey4@cornell.edu</td><td>Thailand</td><td data-tablesort-value="19821004">10/04/1982</td></tr>
    <tr><td>6</td><td>Rani</td><td>Meatyard</td><td>rmeatyard5@twitpic.com</td><td>China</td><td data-tablesort-value="18980910">09/10/1898</td></tr>
    <tr><td>7</td><td>Bianka</td><td>Spellacy</td><td>bspellacy6@icq.com</td><td>United States</td><td data-tablesort-value="19120828">08/28/1912</td></tr>
    <tr><td>8</td><td>Dianna</td><td>Jouaneton</td><td>djouaneton7@samsung.com</td><td>Montenegro</td><td data-tablesort-value="19151204">12/04/1915</td></tr>
    <tr><td>9</td><td>Emlyn</td><td>Preator</td><td>epreator8@chicagotribune.com</td><td>Indonesia</td><td data-tablesort-value="19540313">03/13/1954</td></tr>
    <tr><td>10</td><td>Kellie</td><td>Leipelt</td><td>kleipelt9@columbia.edu</td><td>China</td><td data-tablesort-value="19761203">12/03/1976</td></tr>
    <tr><td>11</td><td>Trisha</td><td>Giorgioni</td><td>tgiorgionia@cloudflare.com</td><td>Bosnia and Herzegovina</td><td data-tablesort-value="19610730">07/30/1961</td></tr>
    <tr><td>12</td><td>Lyn</td><td>Gault</td><td>lgaultb@google.es</td><td>Portugal</td><td data-tablesort-value="19710320">03/20/1971</td></tr>
    <tr><td>13</td><td>Carolan</td><td>Redgrave</td><td>credgravec@twitpic.com</td><td>Argentina</td><td data-tablesort-value="19310912">09/12/1931</td></tr>
    <tr><td>14</td><td>Adler</td><td>Fasset</td><td>afassetd@sohu.com</td><td>Albania</td><td data-tablesort-value="19610515">05/15/1961</td></tr>
    <tr><td>15</td><td>Lucretia</td><td>Huxton</td><td>lhuxtone@pen.io</td><td>Colombia</td><td data-tablesort-value="18961117">11/17/1896</td></tr>
  </tbody>
</table> 
</code></pre>



</div>



</div>

</div>