#ifndef LCMS_ANALYSER_LIB_ADV_H_
#define LCMS_ANALYSER_LIB_ADV_H_

#include "LcmsAnalyserLib.h"

//Reading surface data of the road section
LCMSANALYSERLIB_API ERROR_CODE NAME_CONV LcmsGetRngData(float * _pXData[2], float * _pZData[2], float *_pfInvalidDataVal);
LCMSANALYSERLIB_API ERROR_CODE NAME_CONV LcmsGetTimeStamps(double * _pdTimeStamps[2]);

#endif
