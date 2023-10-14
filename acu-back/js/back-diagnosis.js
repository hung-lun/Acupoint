var logout1 = document.getElementById("logout");
logout1.addEventListener("click", logout);
    function logout() {
        if (confirm('確認要登出嗎？') == true) {
            window.location.href = "../acu-front/login.html";
            localStorage.clear();
        } else {

        }
    }
    

    //JSON 檔案網址
  const url = "https://localhost:7105/api/Eye_question/GetQuestion";
  let data = [];
  fetch(url) //判斷api有沒有資料
    .then((response) => {
      if (response.ok) {
        //如果api有資料就執行以下程式碼顯示資料

        // step 1 - 取得資料
        (function getData() {
          axios.get(url).then(function (response) {
            // 檢查
            console.log(response.data);
            // 將取得資料帶入空陣列data中
            data = response.data;
            const eightdata = data.slice(0,8);
            const fourdata = data.slice(8,12);
            const threedata = data.slice(12,15);
            console.log(eightdata);
            data = eightdata;
            data1 = fourdata;
            data2 = threedata;
            title(data);
            title1(data1);
            title2(data2);
          });
        })();

        function title(arr) {
          // 抓取欄位
          const p_title = document.querySelector(".table_content");
          let str = "";
          // 將資料存入
          arr.forEach(function (data) {
            str += `
                    <tr>
                        <td class="Q-title">○　<input type="text" value="${data.eye_question_content}"><input id="${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"><input id="${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></td>
                    </tr>
            `;
          });
          p_title.innerHTML = str;
        }

        function title1(arr) {
          // 抓取欄位
          const p_title1 = document.querySelector(".table_content1");
          let str1 = "";
          // 將資料存入
          arr.forEach(function (data) {
            str1 += `
                    <tr>
                        <td class="Q-title">○　<input type="text" value="${data.eye_question_content}"><input id="${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"><input id="${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></td>
                    </tr>
            `;
          });
          p_title1.innerHTML = str1;
          }


          function title2(arr) {
          // 抓取欄位
          const p_title2 = document.querySelector(".table_content2");
          let str2 = "";
          // 將資料存入
          arr.forEach(function (data) {
            str2 += `
                    <tr>
                        <td class="Q-title">○　<input type="text" value="${data.eye_question_content}"><input id="${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"><input id="${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></td>
                    </tr>
            `;
          });
          p_title2.innerHTML = str2;


          }}});