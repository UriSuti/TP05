let segs = parseInt(sessionStorage.getItem("segs")) || 0;
let mins = parseInt(sessionStorage.getItem("mins")) || 0;

function mostrarTiempo() {
  const formatoMins = mins.toString().padStart(2, '0');
  const formatoSegs = segs.toString().padStart(2, '0');
  document.getElementById('tiempo').innerHTML = `${formatoMins}:${formatoSegs}`;
}

mostrarTiempo();

setInterval(() => {
  segs++;
  if (segs >= 60) {
    segs = 0;
    mins++;
  }

  sessionStorage.setItem("segs", segs);
  sessionStorage.setItem("mins", mins);

  mostrarTiempo();
}, 1000);
