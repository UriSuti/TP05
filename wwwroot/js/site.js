let segs = parseInt(sessionStorage.getItem("segs")) || 0;
let mins = parseInt(sessionStorage.getItem("mins")) || 0;
let horas = parseInt(sessionStorage.getItem("horas")) || 0;

document.getElementById('tiempo').innerHTML = `tu tiempo es ${horas} : ${mins} : ${segs}` ;


setInterval(() => {
    
    segs++;
    if(segs >= 60){
        segs = 0
        mins++
        if(mins >= 60){
            mins = 0
            horas++
        }
    }
    document.getElementById('tiempo').innerHTML = `tu tiempo es ${horas} : ${mins} : ${segs}` ;

    sessionStorage.setItem("segs", segs);
    sessionStorage.setItem("mins", mins);
    sessionStorage.setItem("horas", horas);

}, 1000);