

document.addEventListener("DOMContentLoaded", function () {
    console.log("Script de acordeón cargado correctamente");

    const botones = document.querySelectorAll(".section-title");

    botones.forEach(boton => {
        boton.addEventListener("click", function () {
            // Buscamos el div con la clase 'section-content' que está justo debajo
            const contenido = this.nextElementSibling;

            if (contenido) {
                console.log("Abriendo/Cerrando sección...");
                contenido.classList.toggle("is-visible");

                // Cambiamos el estado de aria-expanded para accesibilidad
                const expandido = this.getAttribute("aria-expanded") === "true";
                this.setAttribute("aria-expanded", !expandido);
            }
        });
    });
});