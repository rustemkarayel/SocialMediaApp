//onclick like
function like() {
  var like = document.querySelectorAll("#heart");
  var i;
  for (i = 0; i < like.length; i++) {
    like[i].style.visibility = "visible";
  }
}
//send user input
function send() {
  var usermsg = document.getElementById("send-input").value;
  var senddiv = document.querySelector(".user-input");
  senddiv.style.display = "block";
  senddiv.innerHTML = usermsg;
}
