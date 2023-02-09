/*File Upload*/

checkForDeleteBtnVisibility();
checkForNull();

function checkForNull() {
  if (document.getElementsByClassName("imageDisplay")[0].src.includes("/user_interface/assets/default.png")
    && document.getElementsByClassName("imageDisplay")[1].src.includes("/user_interface/assets/default.png")
    && document.getElementsByClassName("imageDisplay")[2].src.includes("/user_interface/assets/default.png")) {
    document.getElementById("updateBtn").disabled = true;
  }
}

function checkForDeleteBtnVisibility() {
  //display delete icon is none as loading
  var carpiList = document.getElementsByTagName("ion-icon");
  var imageList = document.getElementsByClassName("imageDisplay");
  for (var i = 0; i < 3; i++) {
    var src = imageList[i].src;
    if (src.includes("/user_interface/assets/default.png")) {
      carpiList[i].style.display = "none";
    }
    else {
      carpiList[i].style.display = "block";
    }
  }
}

// File Size
function returnFileSize(number) {
  if (number < 1024) {
    return `${number} bytes`;
  } else if (number >= 1024 && number < 1048576) {
    return `${(number / 1024).toFixed(1)} KB`;
  } else if (number >= 1048576) {
    return `${(number / 1048576).toFixed(1)} MB`;
  }
}

//Photo Remove
function photoRemove(imgInput, sizeLabel, imgSrc, nameLabel, i) {

  var carpi = document.getElementsByClassName("carpi")[i];
  carpi.style.display = "none";
  document.getElementById(imgInput).value = "";
  document.getElementById(sizeLabel).innerHTML = "";
  document.getElementById(imgSrc).src = "/user_interface/assets/default.png";
  document.getElementById(nameLabel).innerHTML = "Photo removed!";
  document.getElementById(nameLabel).style.color = "red";
  document.getElementById(nameLabel).style.textAlign = "center";
  checkForNull();
}


function clickImagePicker(imageDisplay, imageName, imageSize, i) {

  var imgFile = document.getElementsByClassName("file_upload")[i].files[0];
  var sizeLabel = document.getElementById(imageSize);
  var img = document.getElementById(imageDisplay);
  var imgName = document.getElementById(imageName);
  var deleteIcon = document.getElementsByTagName("ion-icon")[i];
  var btn = document.getElementById("updateBtn");
  if (img != null) {
    img.src = window.URL.createObjectURL(imgFile);
    imgName.innerHTML = imgFile.name;
    deleteIcon.style.display = "block";
    if (imgFile.size > 819200) {
      sizeLabel.innerHTML = "Cannot be more than 800 kilobytes";
      sizeLabel.style.color = "red";
      btn.disabled = true;
    }
    else {
      sizeLabel.innerHTML = returnFileSize(imgFile.size);
      sizeLabel.style.color = "black";
      btn.disabled = false;
    }
  }
  else {
    sizeLabel.innerHTML = "";
    imgName.innerHTML = "No Photo!";
    img.src = "/user_interface/assets/default.png";
    deleteIcon.style.display = "none";
    checkForNull();
  }
}
