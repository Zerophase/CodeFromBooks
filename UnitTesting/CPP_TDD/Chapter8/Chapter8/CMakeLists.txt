project(Chapter8Tests)
cmake_minimum_required(VERSION 2.6)

include_directories($ENV{BOOST_HOME}/  $ENV{CPPUTEST_HOME}/include)
link_directories($ENV{CPPUTEST_HOME}/lib)
set(Boost_USE_STATIC_LIBS ON)

add_definitions(-std=c++0x)

set(CMAKE_CXX_FLAGS "${CMAXE_CXX_FLAGS} -DRLOG_COMPONENT=debug -Wall")
set(sources WavReader.cpp WavDescriptor.cpp)
set(testSources WavReaderTests.cpp)
add_executable(utest testmain.cpp ${testSources} ${sources})
add_executable(Chapter8 testmain.cpp ${sources})

#SET(CMAKE_INCLUDE_PATH ${CMSKER_INCLUDE_PATH} "C:\Users\Zerophase\Desktop\boost_1_56_0")
#SET(CMAKE_LIBRARY_PATH ${CMAKE_LIBRARY_PATH} "C:\Users\Zerophase\Desktop\boost_1_56_0\libs")
find_package(Boost $ENV{BOOST_VERSION} COMPONENTS filesystem system)
target_link_libraries(utest ${Boost_LIBRARIES})
target_link_libraries(utest CppUTestd)
#target_link_libraries(utest pthread)
#target_link_libraries(utest rt)
#target_link_libraries(utest rlog)

target_link_libraries(Chapter8 ${Boost_LIBRARIES})
#target_link_libraries(Chapter8 pthread)
#target_link_libraries(Chapter8 rlog)

