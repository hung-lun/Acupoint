function nextt() {
    var mail = document.getElementById("mail").value;
    var pwd = document.getElementById("pwd").value;
    var pwdcheck = document.getElementById("pwdcheck").value;
    var name = document.getElementById("name").value;
    var sex = document.getElementById("sex").value;
    var age = document.getElementById("age").value;


    //email格式
    function validateEmail(mail) {
        const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return regex.test(mail);
    }


    if (mail == "" || pwd == "" || pwdcheck == "" || name == "" || sex == "" || age == "") {
        alert("欄位不可為空");
        return false;
    }else if (!validateEmail(mail)) {
        alert('信箱格式錯誤請重新輸入');
        return false;
    }else if (pwd !== pwdcheck) {
        alert("請輸入相同密碼");
        return false;
    }else if(age <= 0){
        alert("年齡不可小於1");
        return false;
    }else{
        console.log(mail,pwdcheck,name,sex,age);
    const formData = new FormData();
    formData.append("user_account", mail);
    formData.append("user_password", pwdcheck);
    formData.append("user_name", name);
    formData.append("user_gender", sex);
    formData.append("user_age", age);
    axios
      .post("https://localhost:7105/api/User/Register", formData, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        console.log("Response:", response.data);
        // alert("驗證碼已發送至信箱");
        alert(response.data.message);
        window.location.href = "./signup-verification.html?Account=" + mail;
      })
      .catch((error) => {
        console.error("Error:", error);
        alert(error.response.data);
      });
        
    }
}