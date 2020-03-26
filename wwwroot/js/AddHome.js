var appartment = document.getElementsByClassName("appartment");
var home = document.getElementsByClassName("home");
var type = document.getElementById("type");
var declaration = document.getElementById("declaration");
var energy = document.getElementsByClassName("energy");


type.onchange = function () {
    if (type.value != "Bostadsrätt") {
        for (var i = 0; i < appartment.length; i++) {
            appartment[i].style.display = "none";
        }
        for (var i = 0; i < home.length; i++) {
            home[i].style.display = "block";
        }
    }
        else {
            for (var i = 0; i < appartment.length; i++) {
                appartment[i].style.display = "block";
        }
        for (var i = 0; i < home.length; i++) {
            home[i].style.display = "none";
        }
    }
};

declaration.onchange = function () {
    if (declaration.checked == true) {
        for (var i = 0; i < energy.length; i++) {
            energy[i].style.display = "block";
        }
    }else {
        for (var i = 0; i < energy.length; i++) {
            energy[i].style.display = "none";
        }
        }
    }

for (var i = 0; i < energy.length; i++) {
    energy[i].style.display = "none";
}
for (var i = 0; i < appartment.length; i++) {
    appartment[i].style.display = "none";
}