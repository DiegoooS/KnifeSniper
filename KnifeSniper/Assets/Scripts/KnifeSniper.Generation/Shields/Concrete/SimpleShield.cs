using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeSniper.Generation
{
    public class SimpleShield : BaseShield
    {
        private float currentNormalizedTime; // Percent
        private float duration;
        private float startTime;
        private Vector3 startAngle;
        private Vector3 endAngle;

        private int currentStep;

        public override void Rotate()
        {
            currentNormalizedTime = (Time.time - startTime) / duration;

            if (currentNormalizedTime >= 1f)
            {
                currentStep++;

                if (currentStep == shieldMovementStep.Length)
                {
                    currentStep = 0;
                }

                var currentStepData = shieldMovementStep[currentStep];

                startTime = Time.time;
                duration = currentStepData.time;
                currentNormalizedTime = 0;
                startAngle = transform.rotation.eulerAngles;
                endAngle = startAngle + Vector3.forward * currentStepData.angle;
            }

            var finalAngle = Vector3.Lerp(startAngle, endAngle, currentNormalizedTime);
            transform.rotation = Quaternion.Euler(finalAngle);
        }

        public override void Initialize()
        {
            currentStep = 0;
            var currentStepData = shieldMovementStep[currentStep];

            duration = currentStepData.time;
            startTime = Time.time;
            currentNormalizedTime = 0f;
            startAngle = transform.rotation.eulerAngles;
            endAngle = startAngle + Vector3.forward * currentStepData.angle;
        }
    } 
}
