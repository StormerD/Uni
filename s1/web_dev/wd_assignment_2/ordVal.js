function validate() {
  /* variable bank */
  var IceCream1 = document.getElementById("oneOrdCntInp").value;
  var IceCream2 = document.getElementById("twoOrdCntInp").value;
  var IceCream3 = document.getElementById("threeOrdCntInp").value;
  var uemail = document.getElementById("uemail").value;
  var uphone = document.getElementById("uphone").value;
  var dMethod = document.getElementById("dMethod").checked;
  var pMethod = document.getElementById("pMethod").checked;
  var bAddress = document.getElementById("bAddress").value;
  var bPC = document.getElementById("bPC").value;
  var dAddress = document.getElementById("dAddress").value;
  var dPC = document.getElementById("dPC").value;
  var onlineMethod = document.getElementById("onlineMethod").checked;
  var pickupMethod = document.getElementById("pickupMethod").checked;
  var cType = document.getElementById("cType").value;
  var cNum = document.getElementById("cNum").value;
  var cName = document.getElementById("cName").value;
  var cDate = document.getElementById("cDate").value;
  var cPin = document.getElementById("cPin").value;

  /* hidden elements */
  var h2 = document.getElementById("hidden2");
  var h3 = document.getElementById("hidden3");

  /* error messages */
  var orderError = document.getElementById("orderError");
  var emailError = document.getElementById("emailError");
  var phoneError = document.getElementById("phoneError");
  var methodError = document.getElementById("methodError");
  var bAddressError = document.getElementById("bAddressError");
  var dAddressError = document.getElementById("dAddressError");
  var payMethodError = document.getElementById("payMethodError");
  var cardError = document.getElementById("cardError");
  var cNumError = document.getElementById("cNumError");
  var cPinError = document.getElementById("cPinError");

  /* misc vars */
  result = true;
  numPat = /^[0-9]+$/;
  atPat = /^[^@]+@[^@]+$/;
  errCount = 0;

  /* clear error messages */
  errorClr();

  /* Rule 1, check if inputs are blank */
  if (IceCream1 == "0" && IceCream2 == "0" && IceCream3 == "0") {
    // check ice cream order
    orderError.innerHTML = "Please select an Ice-Cream";
    errCount = errCount + 1;
  }
  if (uemail == "") {
    emailError.innerHTML = "Please enter your email";
    errCount = errCount + 1;
  }
  if (uphone == "") {
    phoneError.innerHTML = "Please enter your contact number";
    errCount = errCount + 1;
  }
  if (!dMethod && !pMethod) {
    methodError.innerHTML = "Please select an option";
    errCount = errCount + 1;
  }
  if (bAddress == "") {
    bAddressError.innerHTML = "Please enter your billing address";
    errCount = errCount + 1;
  }
  if (dAddress == "") {
    dAddressError.innerHTML = "Please enter your billing address";
    if (h2.style.display != "none") {
      errCount = errCount + 1;
    }
  }
  if (!onlineMethod && !pickupMethod) {
    payMethodError.innerHTML = "Please select an option";
    errCount = errCount + 1;
  }
  if (cType == "" || cNum == "" || cName == "" || cDate == "" || cPin == "") {
    cardError.innerHTML = "Please fill out all fields";
    if (h3.style.display != "none") {
      errCount = errCount + 1;
    }
  }

  /* Rule 2, contact number, post codes, card number and pin have to be ints */
  if (uphone != "" && !uphone.match(numPat)) {
    phoneError.innerHTML = "Phone number can only contain numbers";
    errCount = errCount + 1;
  }
  if (bPC != "" && !bPC.match(numPat)) {
    if (bAddressError.innerHTML != "") {
      bAddressError.innerHTML += " and post code can only be numbers";
      errCount = errCount + 1;
    } else {
      bAddressError.innerHTML = "Post code can only be numbers";
      errCount = errCount + 1;
    }
  }
  if (dPC != "" && !dPC.match(numPat)) {
    if (dAddressError.innerHTML != "") {
      dAddressError.innerHTML += " and post code can only be numbers";
      if (h2.style.display != "none") {
        errCount = errCount + 1;
      }
    } else {
      dAddressError.innerHTML = "Post code can only be numbers";
      if (h2.style.display != "none") {
        errCount = errCount + 1;
      }
    }
  }
  if (cNum != "" && !cNum.match(numPat)) {
    cNumError.innerHTML = "Numbers only";
    if (h3.style.display != "none") {
      errCount = errCount + 1;
    }
  }
  if (cPin != "" && !cPin.match(numPat)) {
    cPinError.innerHTML = "Numbers only";
    if (h3.style.display != "none") {
      errCount = errCount + 1;
    }
  }

  /* Rule 3, min lengths */
  if (bPC.length != 4) {
    if (bAddressError.innerHTML != "") {
      bAddressError.innerHTML += " and post code must be 4 digits";
      errCount = errCount + 1;
    } else {
      bAddressError.innerHTML = "Post code must be 4 digits";
      errCount = errCount + 1;
    }
  }
  if (dPC.length != 4) {
    if (dAddressError.innerHTML != "") {
      dAddressError.innerHTML += " and post code must be 4 digits";
      if (h2.style.display != "none") {
        errCount = errCount + 1;
      }
    } else {
      dAddressError.innerHTML = "Post code must be 4 digits";
      if (h2.style.display != "none") {
        errCount = errCount + 1;
      }
    }

    /* Rule 4, check required symbols */
    if (!uemail.match(atPat)) {
      emailError.innerHTML = "Please enter a valid email";
      errCount = errCount + 1;
    }
  }

  /* error counter */
  if (errCount != 0) {
    result = false;
  }
  return result;
}

// clear errors function
function errorClr() {
  /* error messages */
  var orderError = document.getElementById("orderError");
  var emailError = document.getElementById("emailError");
  var phoneError = document.getElementById("phoneError");
  var methodError = document.getElementById("methodError");
  var bAddressError = document.getElementById("bAddressError");
  var dAddressError = document.getElementById("dAddressError");
  var payMethodError = document.getElementById("payMethodError");
  var cardError = document.getElementById("cardError");
  var cNumError = document.getElementById("cNumError");
  var cPinError = document.getElementById("cPinError");

  /* reset error messages */
  orderError.innerHTML = "";
  emailError.innerHTML = "";
  phoneError.innerHTML = "";
  methodError.innerHTML = "";
  bAddressError.innerHTML = "";
  dAddressError.innerHTML = "";
  payMethodError.innerHTML = "";
  cardError.innerHTML = "";
  cNumError.innerHTML = "";
  cPinError.innerHTML = "";
}

// changes card number maxlength attribute based on what card is selected
function cardSelect() {
  var cType = document.getElementById("cType").value;
  var cNum = document.getElementById("cNum");

  /* If statements */
  if (cType == "visa" || cType == "mastercard") {
    cNum.setAttribute("maxlength", "16");
  } else if (cType == "aexpress") {
    cNum.setAttribute("maxlength", "15");
  }
}

// 1 Minus Count
function oneMClick() {
  if (parseInt(document.getElementById("oneOrdCntDiv").innerHTML) > 0) {
    var ordCount = parseInt(document.getElementById("oneOrdCntDiv").innerHTML);
    ordCount = ordCount - 1;
    document.getElementById("oneOrdCntDiv").innerHTML = ordCount.toString();
    document.getElementById("oneOrdCntInp").value = ordCount.toString();
  }
}

// 1 Add Count
function onePClick() {
  var ordCount = parseInt(document.getElementById("oneOrdCntDiv").innerHTML);
  ordCount = ordCount + 1;
  document.getElementById("oneOrdCntDiv").innerHTML = ordCount.toString();
  document.getElementById("oneOrdCntInp").value = ordCount.toString();
}

// 2 Minus Count
function twoMClick() {
  if (parseInt(document.getElementById("twoOrdCntDiv").innerHTML) > 0) {
    var ordCount = parseInt(document.getElementById("twoOrdCntDiv").innerHTML);
    ordCount = ordCount - 1;
    document.getElementById("twoOrdCntDiv").innerHTML = ordCount.toString();
    document.getElementById("twoOrdCntInp").value = ordCount.toString();
  }
}

// 2 Add Count
function twoPClick() {
  var ordCount = parseInt(document.getElementById("twoOrdCntDiv").innerHTML);
  ordCount = ordCount + 1;
  document.getElementById("twoOrdCntDiv").innerHTML = ordCount.toString();
  document.getElementById("twoOrdCntInp").value = ordCount.toString();
}

// 3 Minus Count
function threeMClick() {
  if (parseInt(document.getElementById("threeOrdCntDiv").innerHTML) > 0) {
    var ordCount = parseInt(
      document.getElementById("threeOrdCntDiv").innerHTML
    );
    ordCount = ordCount - 1;
    document.getElementById("threeOrdCntDiv").innerHTML = ordCount.toString();
    document.getElementById("threeOrdCntInp").value = ordCount.toString();
  }
}

// 3 Add Count
function threePClick() {
  var ordCount = parseInt(document.getElementById("threeOrdCntDiv").innerHTML);
  ordCount = ordCount + 1;
  document.getElementById("threeOrdCntDiv").innerHTML = ordCount.toString();
  document.getElementById("threeOrdCntInp").value = ordCount.toString();
}

// expand delivery address
function expand1() {
  document.getElementById("hidden1").style.display = "block";
  document.getElementById("sameAs").type = "checkbox";
  document.getElementById("hidden2").style.display = "block";
  document.getElementById("dAddress").type = "text";
  document.getElementById("dPC").type = "text";
}

// hide delivery address
function hide1() {
  document.getElementById("hidden1").style.display = "none";
  document.getElementById("sameAs").type = "hidden";
  document.getElementById("hidden2").style.display = "none";
  document.getElementById("dAddress").type = "hidden";
  document.getElementById("dPC").type = "hidden";
}

// expand payment
function expand2() {
  document.getElementById("hidden3").style.display = "block";
  document.getElementById("cNum").type = "text";
  document.getElementById("cName").type = "text";
  document.getElementById("cDate").type = "month";
  document.getElementById("cPin").type = "text";
}

// hide payment
function hide2() {
  document.getElementById("hidden3").style.display = "none";
  document.getElementById("cNum").type = "hidden";
  document.getElementById("cName").type = "hidden";
  document.getElementById("cDate").type = "hidden";
  document.getElementById("cPin").type = "hidden";
}

// same as billing address function
function sameAsAddress() {
  /* var bank */
  var bAddress = document.getElementById("bAddress").value;
  var bPC = document.getElementById("bPC").value;
  var sameAs = document.getElementById("sameAs").checked;
  var sameAsError = document.getElementById("sameAsError");
  var numPat = /^[0-9]+$/;

  if (sameAs) {
    if (bAddress == "") {
      sameAsError.innerHTML = "Please enter your address";
      if (bPC == "") {
        sameAsError.innerHTML += " and post code first";
        document.getElementById("sameAs").checked = false;
        document.getElementById("dAddress").value = "";
        document.getElementById("dPC").value = "";
      } else {
        sameAsError.innerHTML += " first";
        document.getElementById("sameAs").checked = false;
        document.getElementById("dAddress").value = "";
      }
    } else if (bPC == "") {
      sameAsError.innerHTML = "Please enter a post code first";
      document.getElementById("sameAs").checked = false;
      document.getElementById("dPC").value = "";
    } else if (bPC.length != 4) {
      sameAsError.innerHTML = "Post code must be 4 digits";
      document.getElementById("sameAs").checked = false;
    } else if (!bPC.match(numPat)) {
      sameAsError.innerHTML = "Post code can only contain numbers";
      document.getElementById("sameAs").checked = false;
    } else {
      sameAsError.innerHTML = "";
      document.getElementById("dAddress").value = bAddress;
      document.getElementById("dPC").value = bPC;
    }
  }
}

function rButtonFunction() {
  hide1();
  hide2();
  errorClr();
  document.getElementById("oneOrdCntDiv").innerHTML = "0";
  document.getElementById("oneOrdCntInp").value = "0";
  document.getElementById("twoOrdCntDiv").innerHTML = "0";
  document.getElementById("twoOrdCntInp").value = "0";
  document.getElementById("threeOrdCntDiv").innerHTML = "0";
  document.getElementById("threeOrdCntInp").value = "0";
}

// initiate function
function init() {
  /* initiate validation */
  document.getElementById("ordForm").onsubmit = validate;

  /* initiate order buttons */
  document.getElementById("oneM").onclick = oneMClick;
  document.getElementById("oneP").onclick = onePClick;
  document.getElementById("twoM").onclick = twoMClick;
  document.getElementById("twoP").onclick = twoPClick;
  document.getElementById("threeM").onclick = threeMClick;
  document.getElementById("threeP").onclick = threePClick;

  /* initiate hide functions */
  document.getElementById("dMethod").onclick = expand1;
  document.getElementById("pMethod").onclick = hide1;

  document.getElementById("onlineMethod").onclick = expand2;
  document.getElementById("pickupMethod").onclick = hide2;

  /* initiate card type function */
  document.getElementById("cType").onchange = cardSelect;

  /* initiate sameAsAddress function */
  document.getElementById("sameAs").onchange = sameAsAddress;
  document.getElementById("bAddress").oninput = sameAsAddress;
  document.getElementById("bPC").oninput = sameAsAddress;

  /* initiate reset button */
  document.getElementById("rButton").onclick = rButtonFunction;

  /* hide hidden elements */
  hide1();
  hide2();
}

window.onload = init;