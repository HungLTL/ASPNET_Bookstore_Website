<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>The Books Lover | Ebookstore</title>
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
    <div class="header">
      <div class="container">
        <div class="navbar">
          <div class="logo">
            <a href="index.html">
              <img src="images/EbookStore-Logo.png" alt="EbookStore-Logo"
            /></a>
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
        <div class="row">
          <div class="col-2">
            <h1>
              The Books Lover<br />
              Read all About it!
            </h1>
            <p>
              Lorem ipsum dolor sit amet consectetur, adipisicing elit.<br />
              Incidunt voluptas, porro nisi beatae inventore consequuntur?
            </p>
            <a href="ebooks.html" class="btn">Explore Now &#x27F6;</a>
          </div>
          <div class="col-2">
            <img src="images/header-pic.png" alt="Header Pic" />
          </div>
        </div>
      </div>
    </div>
    <!----------------featured categories -------------------->
    <div class="categories">
      <div class="small-container">
        <div class="row">
          <div class="col-3">
            <img src="images/Book 1.jpg" alt="Book 1" />
          </div>
          <div class="col-3">
            <img src="images/Book 2.jpg" alt="Book 2" />
          </div>
          <div class="col-3">
            <img src="images/Book 3.jpg" alt="Book 3" />
          </div>
        </div>
      </div>
    </div>
    <!----------------featured Books -------------------->
    <div class="small-container">
      <h2 class="title">Featured Titles</h2>
      <div class="row">
        <div class="col-4">
          <a href="book-detail.html">
            <img src="images/Book 4.jpg" alt="Book 4"
          /></a>
          <a href="book-detail.html"> <h4>Anna Karenina</h4></a>
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
      <h2 class="title">Bestsellers</h2>
      <div class="row">
        <div class="col-4">
          <img src="images/Book 8.jpg" alt="Book 8" />
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
          <img src="images/Book 9.jpg" alt="Book 9" />
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
          <img src="images/Book 10.jpg" alt="Book 10" />
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
          <img src="images/Book 11.jpg" alt="Book 11" />
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
      <div class="row">
        <div class="col-4">
          <img src="images/Book 12.jpg" alt="Book 12" />
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
          <img src="images/Book 13.jpg" alt="Book 13" />
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
          <img src="images/Book 14.jpg" alt="Book 14" />
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
          <img src="images/Book 15.jpg" alt="Book 15" />
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
    <!------------------offer ------------>
    <div class="offer">
      <div class="small-container">
        <div class="row">
          <div class="col-2">
            <img src="images/offer-Book.jpg" class="offer-img" />
          </div>
          <div class="col-2">
            <p>Available on EbookStore</p>
            <br />
            <h2>I Don't Want To Die Poor</h2>
            <br />
            <small>
              Making Michael Arceneaux's I Don't Want to Die Poor required
              reading in high schools across the country would help a lot of
              young people think twice about the promise that going to college
              at any cost is the only path to upward social mobility.
            </small>
            <a href="#" class="btn">Buy Now &#8594;</a>
          </div>
        </div>
      </div>
    </div>
    <!-- ---------------testimonial-------------------->
    <div class="testimonial">
      <div class="small-container">
        <div div class="row">
          <div class="col-3">
            <i class="fa fa-quote-left"></i>
            <p>
              Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iure
              debitis perferendis, necessitatibus ipsum quia ad sit amet.
            </p>
            <div class="rating">
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star-o"></i>
            </div>
            <img src="images/zeeshan.jpg" alt="zeeshansaeed" />
            <h3>Your Name</h3>
          </div>
          <div class="col-3">
            <i class="fa fa-quote-left"></i>
            <p>
              Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iure
              debitis perferendis, necessitatibus ipsum quia ad sit amet.
            </p>
            <div class="rating">
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star-o"></i>
            </div>
            <img src="images/zeeshan.jpg" alt="zeeshansaeed" />
            <h3>Your Name</h3>
          </div>
          <div class="col-3">
            <i class="fa fa-quote-left"></i>
            <p>
              Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iure
              debitis perferendis, necessitatibus ipsum quia ad sit amet.
            </p>
            <div class="rating">
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star"></i>
              <i class="fa fa-star-o"></i>
            </div>
            <img src="images/zeeshan.jpg" alt="zeeshansaeed" />
            <h3>Your Name</h3>
          </div>
        </div>
      </div>
    </div>
    <!-- ---------------------publishers------------------- -->
    <div class="publishers">
      <div class="small-container">
        <div class="row">
          <div class="col-5">
            <img src="images/publisher1.jpg" />
          </div>
          <div class="col-5">
            <img src="images/publisher2.png" />
          </div>
          <div class="col-5">
            <img src="images/publisher3.jpeg" />
          </div>
          <div class="col-5">
            <img src="images/publisher4.jpg" />
          </div>
          <div class="col-5">
            <img src="images/publisher5.jpg" />
          </div>
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
