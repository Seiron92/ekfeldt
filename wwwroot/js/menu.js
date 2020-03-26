var mnu = document.getElementById("menu");
window.onscroll = function () {
    if (window.pageYOffset >= 10) {
        mnu.style.background = "#fff";
    } else {

        mnu.style.background = "transparent";
    }
}

