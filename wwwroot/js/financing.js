

var typ = document.getElementById("typ");
var city = document.getElementById("city");
var street = document.getElementById("street");
var postal = document.getElementById("postal");
var year = document.getElementById("year");
var price = document.getElementById("price");
var taxeringsvärde = document.getElementById("tax");
var drift = document.getElementById("drift");
var manadsavgift = document.getElementById("manadsavgift");
var boarea = document.getElementById("boarea");
var biarea = document.getElementById("biarea");
var garden = document.getElementById("garden");
var room = document.getElementById("room");
var bildadress = document.getElementById("bildadress");
var lf = document.getElementById("lf");
var nordea = document.getElementById("nordea");
var swed = document.getElementById("swed");

var getUrl = window.location;
var baseUrl = getUrl.protocol + "//" + getUrl.host + "/images/" + bildadress.value.trim();



    
lf.innerHTML = '<a target="blanc" href="https://www.lansforsakringar.se/blekinge/privat/bank/lana/ansok-om-bolan--lanelofte/?sida=2&typ=' + typ.value.trim() + '&byggar=' + year.value.trim() + '&pris=' + price.value.trim() + '&taxering=' + tax.value.trim() + '&drift=' + drift.value.trim() + '&manadsavg=' + manadsavgift.value.trim() + '&boarea=' + boarea.value.trim() + '&antalrum=' + room.value.trim() + '&kommunbenamning=Sverige&bild=' + baseUrl.trim() + '&adress=' + street.value.trim() + '&postnr=' + postal.value.trim() + '&post=' + city.value.trim() + '&utm_campaign=hemnet2014&utm_medium=banner&utm_source=hemnet&utm_content=boende"><img src="/images/lflogo.png" alt="Länsförsäkringar logotyp"/></a>'
nordea.innerHTML = '<a target="blanc" href="https://www.nordea.se/privat/produkter/bolan/bolanekalkyl.html?channel=partner&cid=3632792618&berakobjekt=1&pris=' + price.value.trim() + '&driftskostnad=' + drift.value.trim() + '&taxvarde=' + tax.value.trim() + '&tomtrattsavgald=0&avgift=' + manadsavgift.value.trim() + '&byggnadsar=' + year.value.trim() + '&adress=' + street.value.trim() + '&bild=' + baseUrl.trim() + '"><img src="/images/nordea.png" /></a>'
swed.innerHTML = '<a raeget="blanc" href="https://lana.swedbank.se/app/lana/bolanelofte/oinloggad/valj-bank?pris=' + price.value.trim() + '&drift=' + drift.value.trim() + '&avgift=' + manadsavgift.value.trim() + '&agentnumber=HEM&typ=1&byggar=' + year.value.trim() + '&taxbygg=' + tax.value.trim() + '&arrende=0&tomtrattsavgald=0&adress=' + street.value.trim() + '&kommunkod=0&boarea=' + boarea.value.trim() + '&biarea=' + biarea.value.trim() + '&bild=' + baseUrl.trim()+'"><img src="/images/swed.png" /></a>'
