document
.querySelectorAll(".category-btn")
.forEach(button => {



button.addEventListener("click", function(){



    document
    .querySelectorAll(".category-btn")
    .forEach(btn =>
    {
        btn.classList.remove("active");
    });



    this.classList.add("active");




    let categoryId = this.dataset.category;




    fetch(`/Menu/Filter?categoryId=${categoryId}`)

    .then(response => response.text())

    .then(data => {


        document
        .getElementById("menu-container")
        .innerHTML = data;


    });



});



});