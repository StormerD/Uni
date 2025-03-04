/* form data validation function */
function validate() {
  /* variable bank */
  var uname = document.getElementById("uname").value;
  var pwd1 = document.getElementById("pwd1").value;
  var pwd2 = document.getElementById("pwd2").value;
  var genm = document.getElementById("genm").checked;
  var genf = document.getElementById("genf").checked;
  var favIC = document.getElementById("favIC").value;

  /* error box variables */
  var uErr = document.getElementById("unameError");
  var p1Err = document.getElementById("pwd1Error");
  var p2Err = document.getElementById("pwd2Error");
  var genErr = document.getElementById("genError");
  var favErr = document.getElementById("favError");

  // variable to store error messages
  var errCount = 0;
  // result assumes no errors
  var result = true;

  errorClr();

  /* Rule 1, check if inputs are blank */
  if (uname == "") {
    // check whether uname is empty
    uErr.innerHTML = "Please insert your username.";
    errCount++;
  }
  if (pwd1 == "") {
    // check whether pdw1 is empty
    p1Err.innerHTML = "Please create a password.";
    errCount++;
  }
  if (pwd2 == "") {
    // check whether pdw2 is empty
    p2Err.innerHTML = "Please re-type your password.";
    errCount++;
  }
  if (!genm && !genf) {
    // check whether genm or genf is unchecked
    genErr.innerHTML = "Please select your gender.";
    errCount++;
  }
  if (favIC == "") {
    favErr.innerHTML = "Please select your favorite ice cream flavour.";
    errCount++;
  }

  /* Rule 2, password min 9 characters */
  if (pwd1 != "" && pwd1.length < 9) {
    p1Err.innerHTML = "Password must be at least 9 characters.";
    errCount++;
  }

  /* Rule 3, pdw1 and pdw2 must be the same */
  if (pwd2 != "" && pwd1 != pwd2) {
    p2Err.innerHTML = "Passwords are not the same.";
    errCount++;
  }

  /* prevent form submission if there are errors */
  if (errCount != 0) {
    result = false;
  }

  return result;
}

// clear error function
function errorClr() {
  /* error box variables */
  var uErr = document.getElementById("unameError");
  var p1Err = document.getElementById("pwd1Error");
  var p2Err = document.getElementById("pwd2Error");
  var genErr = document.getElementById("genError");
  var favErr = document.getElementById("favError");

  /* clear error messages */
  uErr.innerHTML = "";
  p1Err.innerHTML = "";
  p2Err.innerHTML = "";
  genErr.innerHTML = "";
  favErr.innerHTML = "";
}

/* assign functions to HTML elements */
function init() {
  document.getElementById("regForm").onsubmit = validate;

  document.getElementById("rButton").onclick = errorClr;
}

/* execute function init() when window is loaded */
window.onload = init;