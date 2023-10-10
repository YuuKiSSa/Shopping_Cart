
window.onload = function () {
    const description = document.querySelectorAll(".description");
    description.forEach(element => {
        const maxHeight = parseInt(getComputedStyle(element).maxHeight);

        if (element.scrollHeight > maxHeight) {
            let text = element.textContent;
            while (element.scrollHeight > maxHeight) {
                text = text.slice(0, -1);
                element.textContent = text + '...';

            }
        }
    })
}
