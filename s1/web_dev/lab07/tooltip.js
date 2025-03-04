/* write functions that define the action for each event */
function sidShowTip() {
  var sidTip = document.getElementById("sidTip");

  sidTip.style.display = "inline";
}

//this function hides the tool tip
function sidHideTip() {
  var sidTip = document.getElementById("sidTip");

  sidTip.style.display = "none";
}
function pdwShowTip() {
  var pdwTip = document.getElementById("pdwTip");

  pdwTip.style.display = "inline";
}

//this function hides the tool tip
function pdwHideTip() {
  var pdwTip = document.getElementById("pdwTip");

  pdwTip.style.display = "none";
}

/* the init function links functions to appropriate events of corresponding HTML elements */
function init() {
  var sid = document.getElementById("sid");
  var pdw = document.getElementById("pdw1");

  sid.onmouseover = sidShowTip;
  sid.onmouseout = sidHideTip;
  pdw.onmouseover = pdwShowTip;
  pdw.onmouseout = pdwHideTip;
}


/* link function init to the onload event of the window so that function init will be called when the page is loaded */
window.onload = init;
