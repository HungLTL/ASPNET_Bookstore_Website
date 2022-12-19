<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Book-detailpage | Ebookstore</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link
      href="https://fonts.googleapis.com/css2?
      family=Poppins:ital,wght@0,200;0,300;0,400;0,500;0,600;1,100;1,200;1,300;1,400;1,500;1,600&display=swap"
      rel="stylesheet"
    />
    <link
      rel="stylesheet"
      href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"
    />
  </head>

  <body>
    <!------------------ Header ------------------>
    <div class="container">
      <div class="navbar">
        <div class="logo">
          <a href="index.html">
            <img src="images/EbookStore-Logo.png" alt="EbookStore-Logo" />
          </a>
        </div>
        <!----------  Nav Bar ------------------>
        <nav>
          <ul id="MenuItems">
            <li><a href="index.html">Home</a></li>
            <li><a href="ebooks.html">Ebooks</a></li>
            <li><a href="">About</a></li>
            <li><a href="">Contact</a></li>
            <li><a href="account.html">Account</a></li>
          </ul>
        </nav>
        <a href="cart.html">
          <img
            src="images/cart.png"
            alt="Shoping Cart"
            width="28px"
            height="28px"
            style="margin-left: 10px; margin-top: 15px"
          />
        </a>
        <img src="images/menu.png" class="menu-icon" onclick="menutoggle()" />
      </div>
    </div>

    <!-- ----------single product details------------- -->
    <div class="small-container single-product">
      <div class="row">
        <div class="col-2">
          <img src="images/Book 16.jpg" alt="Book4" width="68%" />
        </div>
        <div class="col-2">
          <p>Home / Ebook</p>
          <h1>Anna Karenina by LEO TOLSTOY</h1>
          <h4>Rs500.00</h4>
          <input type="number" value="1" />
          <a href="" class="btn">Add To Cart</a>
          <h3>Book Deatails <i class="fa fa-indent"></i></h3>
          <br />
          <p>
            Acclaimed by many as the world's greatest novel, Anna Karenina
            provides a vast panorama of contemporary life in Russia and of
            humanity in general. In it Tolstoy uses his intense imaginative
            insight to create some of the most memorable characters in all of
            literature. Anna is a sophisticated woman who abandons her empty
            existence as the wife of Karenin and turns to Count Vronsky to
            fulfil her passionate nature - with tragic consequences. Levin is a
            reflection of Tolstoy himself, often expressing the author's own
            views and convictions.
          </p>
        </div>
      </div>
    </div>

    <!-- -------------title----------------- -->
    <div class="small-container">
      <div class="row row-2">
        <h2>Related Books</h2>
        <p>View More</p>
      </div>
    </div>
    <!-- --------------Product-------------- -->
    <div class="small-container">
      <div class="row">
        <div class="col-4">
          <img src="images/Book 4.jpg" alt="Book 4" />
          <h4>Anna Karenina</h4>
          <div class="rating">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star-o"></i>
          </div>
          <p>Rs.500</p>
        </div>
        <div class="col-4">
          <img src="images/Book 5.jpg" alt="Book 5" />
          <h4>Watership Down</h4>
          <div class="rating">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star-half-o"></i>
            <i class="fa fa-star-o"></i>
          </div>
          <p>Rs.500</p>
        </div>
        <div class="col-4">
          <img src="images/Book 6.jpg" alt="Book 6" />
          <h4>All The Night We Cannot See</h4>
          <div class="rating">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star-half-o"></i>
          </div>
          <p>Rs.500</p>
        </div>
        <div class="col-4">
          <img src="images/Book 7.jpg" alt="Book 7" />
          <h4>The HOBBIT</h4>
          <div class="rating">
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star"></i>
            <i class="fa fa-star-o"></i>
          </div>
          <p>Rs.500</p>
        </div>
      </div>
    </div>
    <!-- ---------------------footer------------------- -->
    <div class="footer">
      <div class="container">
        <div class="row">
          <div class="footer-col-1">
            <h3>Download Our App</h3>
            <p>Download App for Android and ios mobile phone.</p>
            <div class="app-logo">
              <img src="images/Playstore.png" />
              <img src="images/Applestore.png" />
            </div>
          </div>
          <div class="footer-col-2">
            <img src="images/EbookStore-Logo-footer.png" />
            <p>
              Lorem ipsum, dolor sit amet consectetur adipisicing elit.
              Reiciendis, Lorem ipsum dolor sit amet.
            </p>
          </div>
          <div class="footer-col-3">
            <h3>Useful Links</h3>
            <ul>
              <li>Coupons</li>
              <li>Blog Post</li>
              <li>Return Policy</li>
              <li>Join Affiliate</li>
            </ul>
          </div>
          <div class="footer-col-4">
            <h3>Follow us</h3>
            <ul>
              <li>Facebook</li>
              <li>Youtube</li>
              <li>Instagram</li>
              <li>Twitterr</li>
            </ul>
          </div>
        </div>
        <hr />
        <p class="copyright">Copyright 2020 - EbookStore</p>
      </div>
    </div>
    <!-- ---------Javascript for toggle menu------------- -->
    <script>
      var MenuItems = document.getElementById("MenuItems");
      MenuItems.style.maxHeight = "0px";
      function menutoggle() {
        if (MenuItems.style.maxHeight == "0px") {
          MenuItems.style.maxHeight = "200px";
        } else {
          MenuItems.style.maxHeight = "0px";
        }
      }
    </script>
  </body>
</html>
