/*File Upload*/

function changeContent() {
  var file = document.getElementById('image_file').files[0];
  //file.name == "photo.png"
  //file.type == "image/png"
  //file.size == 300821
  document.getElementById('imageDisplay').src = window.URL.createObjectURL(file);
  document.getElementById('imageName').innerHTML = file.name;
  var btn = document.getElementById('addBtn');
  var sizeLabel = document.getElementById('imageSize');

  if (file.size > 819200) {
    sizeLabel.innerHTML = "Cannot be more than 800 kilobytes";
    sizeLabel.style.color = "red";
    btn.disabled = true;
  } else {
    sizeLabel.innerHTML = returnFileSize(file.size);
    sizeLabel.style.color = "white";
    btn.disabled = false;
  }
}

//File Size
function returnFileSize(number) {
  if (number < 1024) {
    return `${number} bytes`;
  } else if (number >= 1024 && number < 1048576) {
    return `${(number / 1024).toFixed(1)} KB`;
  } else if (number >= 1048576) {
    return `${(number / 1048576).toFixed(1)} MB`;
  }
}
