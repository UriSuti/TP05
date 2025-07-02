let segs = parseInt(sessionStorage.getItem("segs")) || 0;
let mins = parseInt(sessionStorage.getItem("mins")) || 0;

document.getElementById('tiempo').innerHTML = `${mins}:${segs}` ;


setInterval(() => {
    
    segs++;
    if(segs >= 60){
        segs = 0
        mins++
    }

    if(segs < 10){

        document.getElementById('tiempo').innerHTML = `${mins}:0${segs}` ;

    }else{

        document.getElementById('tiempo').innerHTML = `${mins}:${segs}` ;

    }


    sessionStorage.setItem("segs", segs);
    sessionStorage.setItem("mins", mins);
    sessionStorage.setItem("horas", horas);

}, 1000);