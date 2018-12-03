window.onscroll = () => {

    if (window.scrollY > 0) {
        document.querySelector("#chat").classList.add('invert');
        document.querySelector("#chat img").src = "/imagens/icones/chat2.png";
    }
    else {
        document.querySelector("#chat").classList.remove('invert');
        document.querySelector("#chat img").src = "/imagens/icones/chat.png";
    }
};

window.addEventListener('load', () => {
    document
        .querySelectorAll(".inputLabel")
        .forEach((e) => {
            //Pega o input
            let input = e.querySelector("input");
            let label = e.querySelector("label");


            input.addEventListener('blur', () => {
                if (input.value.trim().length != 0) {
                    label.classList.add("tem-conteudo");
                }
                else {
                    label.classList.remove("tem-conteudo");
                }
            })

        });
});