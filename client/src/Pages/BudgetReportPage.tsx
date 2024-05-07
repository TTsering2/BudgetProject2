import Footer from "@/Components/Footer";
import Header from "@/Components/Header";
import { FC } from "react";

const BudgetReportPage: FC = () => {
  return (
    <div className="bg-gradient-bluewhite bg-cover bg-center bg-fixed flex flex-col flex-grow w-full min-h-full ">
      <Header />
      <main className="w-10/12 mx-auto flex-grow bg-primary-white mb-8 rounded-md">
        <div className="hello flex flex-col h-full">
          {/* Top Row */}
          <div className="min-h-1/2">
            {/* Content for Top Row */}
            {/* <div className="bg-gray-100 h-96">

            </div> */}
          </div>

          {/* Bottom Row */}
          <div className="grid grid-cols-4 min-h-96">
            {/* Column 1 */}
            <div className="bg-gray-200">Column 1 Content</div>
            {/* Column 2 */}
            <div className="bg-gray-300">Column 2 Content</div>
            {/* Column 3 */}
            <div className="bg-gray-400">Column 3 Content</div>
            {/* Column 4 */}
            <div className="bg-gray-500">Column 4 Content</div>
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
};

export default BudgetReportPage;
