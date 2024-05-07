const Footer = () => {
    return (
        <footer className="footer bg-[#0A2430] text-white p-6">
            <div className="w-10/12 mx-auto">
            <section className="flex flex-row  items-center justify-between pb-4">
                <div className="flex flex-row mr-6 items-center	">
                    <img src="../assets/logo_footer.png" alt="logo" className="mr-4 w-12"></img>
                    <p>SpendWise</p>
                </div>
                <div>
                    <ul className="flex flex-row">
                        <li className="mr-4"><a>About</a></li>
                        <li  className="mr-4"><a>Accessibility</a></li>
                        <li  className="mr-4"><a>FAQ</a></li>
                        <li  className="mr-4"><a>Newsletter</a></li>

                    </ul>
                </div>

                <div className="flex flex-row">
                    <a href=""><img src="../assets/Facebook.svg" className="w-8 mr-2"></img></a>
                    <a href=""><img src="../assets/Instagram.svg" className="w-8  mr-2"></img></a>
                    <a href=""><img src="../assets/LinkedIn.svg" className="w-8  mr-2"></img></a>
                    <a href=""><img src="../assets/Twitter.svg" className="w-8  mr-2"></img></a>
                </div>

            </section>

        <section>
          <p className="text-center border-t-2 p-2">
            Copyright © 2024 SpendWise | All Rights Reserved{" "}
          </p>
        </section>
      </div>
    </footer>
  );
};


export default Footer;
