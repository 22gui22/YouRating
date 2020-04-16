document.getElementById('MainContent_a1').addEventListener("mouseover", function () { mouseOver(1); }, false);
document.getElementById('MainContent_a1').addEventListener("mouseout", function () { mouseOut(1); }, false);
document.getElementById('MainContent_a2').addEventListener("mouseover", function () { mouseOver(2); }, false);
document.getElementById('MainContent_a2').addEventListener("mouseout", function () { mouseOut(2); }, false);
document.getElementById('MainContent_a3').addEventListener("mouseover", function () { mouseOver(3); }, false);
document.getElementById('MainContent_a3').addEventListener("mouseout", function () { mouseOut(3); }, false);
document.getElementById('MainContent_a4').addEventListener("mouseover", function () { mouseOver(4); }, false);
document.getElementById('MainContent_a4').addEventListener("mouseout", function () { mouseOut(4); }, false);
document.getElementById('MainContent_a5').addEventListener("mouseover", function () { mouseOver(5); }, false);
document.getElementById('MainContent_a5').addEventListener("mouseout", function () { mouseOut(5); }, false);

document.getElementById('MainContent_a1').addEventListener("click", function () { click(1); }, false);
document.getElementById('MainContent_a2').addEventListener("click", function () { click(2); }, false);
document.getElementById('MainContent_a3').addEventListener("click", function () { click(3); }, false);
document.getElementById('MainContent_a4').addEventListener("click", function () { click(4); }, false);
document.getElementById('MainContent_a5').addEventListener("click", function () { click(5); }, false);



function mouseOver(id) {
    for (i = 1; i <= id; i++) {
    }
    addStyle(id);
}

function mouseOut(id) {
    for (i = 5; i > 0; i--) {
    }
    removeStyle(id);
}

function click(id) {
    removeStyle(5);
    addStyle(id);
}

function addClass(id) {
    for (i = 1; i <= id; i++) {
        //document.getElementById("MainContent_a" + i).classList.remove('unchecked');
        //document.getElementById("MainContent_a" + i).classList.add('checked');
        document.getElementById("MainContent_a" + i).style.color = "orange";
    }
}

function removeClass(id) {
    for (i = 1; i <= id; i++) {
        //document.getElementById("MainContent_a" + i).classList.remove('checked');
        //document.getElementById("MainContent_a" + i).classList.add('unchecked');
        document.getElementById("MainContent_a" + i).style.color = "grey";
    }
}

function addStyle(id) {
    for (i = 1; i <= id; i++) {
        document.getElementById("MainContent_a"+i).style.color = "orange";
    }
}

function removeStyle(id) {
    for (i = 1; i <= id; i++) {
        //document.getElementById("MainContent_a" + i).removeAttribute("style")
        document.getElementById("MainContent_a" + i).style.color = "grey";
    }
}

