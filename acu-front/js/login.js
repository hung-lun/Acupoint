function login() {
    var user = document.getElementById("user").value;
    var pwd = document.getElementById("pwd").value;
    

    if (user == "" || pwd == "") {

        alert("欄位不得為空");
        return false;

    }else if ((user != "") & (pwd != "")) {

        // if((user != "123") || (pwd != "123")){
        //     alert("帳號或密碼錯誤");
        //     return false;
        // }else 
        if(((user == "123") && (pwd == "123"))){
            window.location.href = "./front-index.html"
        }else if(((user == "111") && (pwd == "111"))){
            window.location.href = "../../back/back-diagnosis.html"
        }else{
            alert("帳號或密碼錯誤");
            return false;
        }

    }
}