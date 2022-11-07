
let index = 0;
let items = document.querySelectorAll(".item-panel");

function tablist1() {
    
    let transition = document.querySelectorAll(".item-panel.t1");
    console.log(transition);
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);

    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[0].classList.add('active');
}
function tablist2() {

    let transition = document.querySelectorAll(".item-panel.t2");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[1].classList.add('active');
}

function tablist3() {

    let transition = document.querySelectorAll(".item-panel.t3");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[2].classList.add('active');
}
function tablist4() {

    let transition = document.querySelectorAll(".item-panel.t4");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[3].classList.add('active');
}

function tablist5() {

    let transition = document.querySelectorAll(".item-panel.t5");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[4].classList.add('active');
}
